using Core.Data;
using Core.Utilities;
using Dapper;
using Dapper.Contrib.Extensions;
using Repository.IRepository;
using System.Data;
using System.Reflection;

namespace Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected IDbTransaction _transaction { get; private set; }
        protected IDbConnection DbConnection => _transaction.Connection;

        public RepositoryBase(IDbTransaction transaction) { _transaction = transaction; }

        protected string EntityName => "tbl" + typeof(T).Name;

        //public virtual IEnumerable<T> GetAll()
        //{
        //    var query = $"SELECT * FROM {EntityName}";
        //    var results = DbConnection.Query<T>(query,transaction:_transaction);
        //    return results;
        //}
        public T SoftDelete(T entity, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContext)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            }
            String? contextUser = httpContext.HttpContext?.User.Claims.FirstOrDefault()?.Value;

            try
            {
                //dbSet.Attach(entity);
                //_context.Entry(entity).State = EntityState.Modified;
                if (entity.GetType().GetProperty("DeletedOn") != null)
                {
                    entity.GetType().GetProperty("DeletedOn").SetValue(entity, DateTime.Now);
                    //_context.Entry(entity).Property("DeletedOn").IsModified = true;
                }
                if (entity.GetType().GetProperty("IsActive") != null)
                {
                    entity.GetType().GetProperty("IsActive").SetValue(entity, false);
                    //_context.Entry(entity).Property("IsActive").IsModified = true;
                }
                if (entity.GetType().GetProperty("DeletedBy") != null)
                {
                    entity.GetType().GetProperty("DeletedBy").SetValue(entity, contextUser);
                    //_context.Entry(entity).Property("DeletedBy").IsModified = true;
                }
                UpdateVoid(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)}" + ex.Message);
            }
        }
        public async void AsyncExecute(string QUERY, object MODEL)
        {
            await DbConnection.ExecuteAsync(QUERY, MODEL, transaction: _transaction);
        }
        public virtual IEnumerable<T> GetAllPaged(int limit, int offset)
        {
            var query = $"SELECT * FROM {EntityName} ORDER BY Id DESC OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
            var results = DbConnection.Query<T>(query, new { Limit = limit, Offset = offset }, transaction: _transaction);
            return results;
        }

        public async Task<IEnumerable<T>> GetAllPagedAsync(int limit, int offset)
        {
            var query = $"SELECT * FROM {EntityName} ORDER BY Id DESC OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
            var results = await DbConnection.QueryAsync<T>(query, new { Limit = limit, Offset = offset }, transaction: _transaction);
            return results;
        }

        public virtual object Insert(T entity)
        {
            var propertyValues = GetEntityProperties(entity);
            var keyInfo = GetEntityKeyInfo();
            var sql = $"INSERT INTO [{EntityName}] ({string.Join(", ", propertyValues.Keys)}) VALUES(@{string.Join(", @", propertyValues.Keys)}) SELECT CAST(scope_identity() AS {GetSqlDataType(keyInfo.PropertyType)})";
            var result = DbConnection.Query(sql, propertyValues, commandType: CommandType.Text, transaction: _transaction).First() as IDictionary<string, object>;
            if (result != null && !keyInfo.IsDefined(typeof(NotDbGeneratedAttribute), false))
            {
                var keyValue = result.Values.ToArray()[0];
                keyInfo.SetValue(entity, Convert.ChangeType(keyValue, keyInfo.PropertyType));
                return keyValue;
            }
            return null;
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public virtual void UpdateVoid(T entity)
        {
            var propertyValues = GetEntityProperties(entity);
            var keyInfo = GetEntityKeyInfo();
            var keyPairs = $"{keyInfo.Name} = @{keyInfo.Name}";
            var pairs = propertyValues.Where(key => key.Key != keyInfo.Name).Select(key => $"{key.Key}=@{key.Key}");
            var updateParameters = string.Join(", ", pairs);
            var sql = $"UPDATE [{EntityName}] SET {updateParameters} WHERE {keyPairs}";
            DbConnection.Execute(sql, entity, commandType: CommandType.Text, transaction: _transaction);
        }

        public virtual void UpdateVoid(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                UpdateVoid(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            var keyInfo = GetEntityKeyInfo();
            var keyPairs = $"{keyInfo.Name} = @{keyInfo.Name}";
            var sql = $"DELETE FROM [{EntityName}] WHERE {keyPairs}";
            DbConnection.Execute(sql, entity, commandType: CommandType.Text, transaction: _transaction);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public virtual void DeleteAll()
        {
            var sql = $"DELETE FROM [{EntityName}]";
            DbConnection.Execute(sql, commandType: CommandType.Text, transaction: _transaction);
        }

        private Dictionary<string, object> GetEntityProperties(T entity)
        {
            var propertyValues = new Dictionary<string, object>();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                // Skip reference types except string
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string) && property.PropertyType != typeof(byte[]))
                    continue;

                // Skip methods without a public setter
                if (property.GetSetMethod() == null)
                    continue;

                // Skip methods specifically ignored
                if (property.IsDefined(typeof(IgnoreAttribute), false))
                    continue;
                // Skip methods specifically ignored
                if (property.CustomAttributes.Any(x => x.AttributeType.Name == "IgnoreAttribute"))
                    continue;

                if (property.IsDefined(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), false) && !property.IsDefined(typeof(NotDbGeneratedAttribute), false))
                    continue;

                var value = property?.GetValue(entity, null);
                propertyValues.Add(property.Name, value);

            }

            return propertyValues;
        }

        private PropertyInfo GetEntityKeyInfo()
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.IsDefined(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), false))
                {
                    return property;
                }
            }

            return null;
        }

        private string GetSqlDataType(Type type)
        {
            if (type == typeof(int))
            {
                return "INT";
            }
            else if (type == typeof(long))
            {
                return "BIGINT";
            }
            else if (type == typeof(byte))
            {
                return "TINYINT";
            }
            else if (type == typeof(short))
            {
                return "SMALLINT";
            }
            else if (type == typeof(Guid))
            {
                return "UNIQUEIDENTIFIER";
            }


            throw new Exception("Key type not supported");
        }

        //Extra
        public TReturn QuerySingle<TReturn>(string storeProcedure, DynamicParameters dynamicParameters)
        {
            using var connection = DbConnection;

            var result = connection.QuerySingle<TReturn>(storeProcedure, dynamicParameters,
            commandType: CommandType.StoredProcedure, transaction: _transaction);

            return result ?? throw new KeyNotFoundException($"{EntityName} could not be found.");
        }

        public IEnumerable<TReturn> Query<TReturn>(string storeProcedure, DynamicParameters dynamicParameters)
        {
            using var connection = DbConnection;

            var result = connection.Query<TReturn>(storeProcedure, dynamicParameters,
            commandType: CommandType.StoredProcedure, transaction: _transaction);

            return result ?? throw new KeyNotFoundException($"{EntityName} could not be found.");
        }

        public int Execute(string storeProcedure, DynamicParameters dynamicParameters) => DbConnection.Execute(storeProcedure, dynamicParameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        public T GetById<TParameter>(TParameter id) where TParameter : struct => DbConnection.Get<T>(id);
        public IEnumerable<T> Get(Func<T, bool> predicate) => DbConnection.Query<T>($"SELECT * FROM {EntityName}", transaction: _transaction).Where(predicate);
        //Async
        public async Task<IEnumerable<T>> GetAllAsync() => await DbConnection.GetAllAsync<T>(transaction: _transaction);
        public async Task<T> GetByIdAsync<TParameter>(TParameter id) where TParameter : struct => await DbConnection.GetAsync<T>(id, transaction: _transaction) ?? throw new KeyNotFoundException("${TableName} with id [{id}] could not be found.");
        public async Task<int> AddAsync(T entity) => await DbConnection.InsertAsync(entity, transaction: _transaction);
        public async Task<bool> UpdateAsync(T entity) => await DbConnection.UpdateAsync(entity, transaction: _transaction);
        public async Task<bool> DeleteAsync(T entity) => await DbConnection.DeleteAsync(entity, transaction: _transaction);
        //Dapper Extra Method
        public void Add(T entity, bool LastInsertId = false) => DbConnection.Insert<T>(entity, transaction: _transaction);
        public bool Add(T entity) => DbConnection.Insert<T>(entity, transaction: _transaction) > 0;
        public bool Delete(int Id) => (int)DbConnection.Execute($"delete from {EntityName} where Id = @Id", param: new { Id }, transaction: _transaction) > 0;
        public bool Update(T entity) => DbConnection.Update<T>(entity, transaction: _transaction);
        public bool Update(List<T> entity) => DbConnection.Update<List<T>>(entity, transaction: _transaction);
        public bool IsExist(string Query) => Count(Query) > 0;
        public bool IsExist(string Query, object model) => Count(Query, model) > 0;
        public IEnumerable<T> List() => GetAll();
        public IEnumerable<T> List(bool OrderByDesc) => DbConnection.Query<T>($"select * from {EntityName} order by Id {(OrderByDesc ? "desc" : "asc")}", transaction: _transaction);
        public IEnumerable<T> List(string Query) => DbConnection.Query<T>($"select * from {EntityName} where 1=1 and {((Query.Length <= 0) ? "1=1" : Query)}", transaction: _transaction);
        public IEnumerable<T> List(string Query, object model) => DbConnection.Query<T>($"select * from {EntityName} where 1=1 and {((Query.Length <= 0) ? "1=1" : Query)}", model, transaction: _transaction);
        public IEnumerable<T> List(int page = 0, int pagesize = 10) => DbConnection.Query<T>($"select * from {EntityName} LIMIT {pagesize} OFFSET {page}", transaction: _transaction);
        public IEnumerable<T> List(string Query, int page = 0, int pagesize = 10) => DbConnection.Query<T>($"select * from {EntityName} where 1=1 and {((Query.Length <= 0) ? "1=1" : Query)} LIMIT {pagesize} OFFSET {page}", transaction: _transaction);
        public ListModel<T> PagedList(int page = 0, int pagesize = 10)
        {
            ListModel<T> ReturnModel = new ListModel<T>(); /*page = (page == 0) ? 1 : page;*/
            ReturnModel.List = DbConnection.Query<T>($"SELECT * FROM {EntityName} ORDER BY Id DESC OFFSET {page} ROWS FETCH NEXT {pagesize} ROWS ONLY", transaction: _transaction).ToList();
            ReturnModel.CurrentPage = page;
            ReturnModel.PageCount = pagesize;
            ReturnModel.ItemCount = Count();
            return ReturnModel;
        }
        public ListModel<T> PagedList(string Query, int page = 0, int pagesize = 10)
        {
            ListModel<T> ReturnModel = new ListModel<T>();
            try
            {
                if (Query.Length > 4)
                    Query = (Query.Trim().Substring(0, 3).ToUpper() == "AND") ? Query.Trim().Remove(0, 3) : Query;
                ReturnModel.List = DbConnection.Query<T>($"select * from {EntityName} where 1=1 and {((Query.Length <= 0) ? "1=1" : Query)} ORDER BY Id DESC OFFSET {page} ROWS FETCH NEXT {pagesize} ROWS ONLY", transaction: _transaction).ToList();
                ReturnModel.CurrentPage = page;
                ReturnModel.PageCount = pagesize;
                ReturnModel.ItemCount = Count(Query);
            }
            catch (Exception ex)
            {
                string mesaj = ex.Message;
            }
            return ReturnModel;
        }
        public ListModel<T> PagedList(string Query, object model, int page = 0, int pagesize = 10)
        {
            ListModel<T> ReturnModel = new ListModel<T>();
            try
            {
                if (Query.Length > 4)
                    Query = (Query.Trim().Substring(0, 3).ToUpper() == "AND") ? Query.Trim().Remove(0, 3) : Query;
                ReturnModel.List = DbConnection.Query<T>($"select * from {EntityName} where 1=1 and {((Query.Length <= 4) ? "1=1" : Query)} ORDER BY Id DESC OFFSET {page} ROWS FETCH NEXT {pagesize} ROWS ONLY", model, transaction: _transaction).ToList();
                ReturnModel.CurrentPage = page;
                ReturnModel.PageCount = pagesize;
                ReturnModel.ItemCount = Count(Query, model);
            }
            catch (Exception ex)
            {
                string mesaj = ex.Message;
            }
            return ReturnModel;
        }
        public IEnumerable<T> GetAll() => DbConnection.Query<T>($"select * from {EntityName}", transaction: _transaction);
        public int Count(string Query, object model) => DbConnection.Query<int>($"select count(*) from {EntityName} where 1=1 and {((Query.Length <= 0) ? "1=1" : Query)} ", model, transaction: _transaction).FirstOrDefault();
        public int Count(string Query) => DbConnection.Query<int>($"select count(*) from {EntityName} where 1=1 and {((Query.Length <= 0) ? "1=1" : Query)} ", null, transaction: _transaction).FirstOrDefault();
        public int Count() => DbConnection.Query<int>($"select count(*) from {EntityName} ", null, transaction: _transaction).FirstOrDefault();
        public int MaxId() => DbConnection.Query<int>($"select max(Id) from {EntityName} ", null, transaction: _transaction).FirstOrDefault();
        public bool Truncate() => (DbConnection.Execute($"truncate {EntityName}", transaction: _transaction) > 0) ? true : false;
        public bool Drop() => (DbConnection.Execute($"drop table if exists {EntityName}", transaction: _transaction) > 0) ? true : false;
        public bool Optimize() => (DbConnection.Execute($"optimize if exists {EntityName}", transaction: _transaction) > 0) ? true : false;
        public bool Lock() => (DbConnection.Execute($"lock tables {EntityName} read", transaction: _transaction) > 0) ? true : false;
        public bool UnLock() => (DbConnection.Execute($"FLUSH TABLES WITH READ LOCK;unlock tables {EntityName}", transaction: _transaction) > 0) ? true : false;
        public bool Repair() => (DbConnection.Execute($"repair table exists {EntityName}", transaction: _transaction) > 0) ? true : false;
        public IEnumerable<T> FindList(int Id) => DbConnection.Query<T>($"select * from {EntityName} where Id = @Id", param: new { Id }, transaction: _transaction);
        public dynamic FreeDynamicQuery(string Query) => DbConnection.Query<dynamic>(Query, null, transaction: _transaction).FirstOrDefault();
        public dynamic FreeDynamicQuery(string Query, object model) => DbConnection.Query<dynamic>(Query, model, transaction: _transaction).FirstOrDefault();
        public T FreeQuerySingle(string Query) => DbConnection.Query<T>(Query, null, transaction: _transaction).FirstOrDefault();
        public T FreeQuerySingle(string Query, object model) => DbConnection.Query<T>(Query, model, transaction: _transaction).FirstOrDefault();
        public IEnumerable<T> FreeQuery(string Query) => DbConnection.Query<T>(Query, null, transaction: _transaction);
        public int FindId(string Query) => DbConnection.QuerySingle<int>($"select Id from {EntityName} where 1=1 and {Query}", null, transaction: _transaction);
        public int FindId(string Query, object model) => DbConnection.QuerySingle<int>($"select Id from {EntityName} where 1=1 and {Query}", model, transaction: _transaction);
        public int PageCount(string Query, int ListCount) => (int)(Count(Query) / ListCount);
        public bool Execute(string Query) => DbConnection.Execute(Query, transaction: _transaction) > 0;
        public bool Execute(string Query, object model) => DbConnection.Execute(Query, model, _transaction) > 0;
        public void Rollback() => _transaction.Rollback();
    }
}
