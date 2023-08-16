using Core.Utilities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        T SoftDelete(T entity, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContext);
        bool Add(T entity);
        void Add(T entity, bool LastInsertId = false);
        Task<int> AddAsync(T entity);
        void AsyncExecute(string QUERY, object MODEL);
        int Count();
        int Count(string Query);
        int Count(string Query, object model);
        void Delete(IEnumerable<T> entities);
        bool Delete(int Id);
        void Delete(T entity);
        void DeleteAll();
        Task<bool> DeleteAsync(T entity);
        bool Drop();
        bool Execute(string Query);
        int Execute(string storeProcedure, DynamicParameters dynamicParameters);
        bool Execute(string Query, object model);
        int FindId(string Query);
        int FindId(string Query, object model);
        IEnumerable<T> FindList(int Id);
        dynamic FreeDynamicQuery(string Query);
        dynamic FreeDynamicQuery(string Query, object model);
        IEnumerable<T> FreeQuery(string Query);
        T FreeQuerySingle(string Query);
        T FreeQuerySingle(string Query, object model);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAllPaged(int limit, int offset);
        Task<IEnumerable<T>> GetAllPagedAsync(int limit, int offset);
        IEnumerable<T> Get(Func<T, bool> predicate);
        T GetById<TParameter>(TParameter id) where TParameter : struct;
        Task<T> GetByIdAsync<TParameter>(TParameter id) where TParameter : struct;
        void Insert(IEnumerable<T> entities);
        object Insert(T entity);
        bool IsExist(string Query);
        bool IsExist(string Query, object model);
        IEnumerable<T> List();
        IEnumerable<T> List(int page = 0, int pagesize = 10);
        IEnumerable<T> List(bool OrderByDesc);
        IEnumerable<T> List(string Query);
        IEnumerable<T> List(string Query, int page = 0, int pagesize = 10);
        IEnumerable<T> List(string Query, object model);
        bool Lock();
        int MaxId();
        bool Optimize();
        int PageCount(string Query, int ListCount);
        ListModel<T> PagedList(int page = 0, int pagesize = 10);
        ListModel<T> PagedList(string Query, int page = 0, int pagesize = 10);
        ListModel<T> PagedList(string Query, object model, int page = 0, int pagesize = 10);
        IEnumerable<TReturn> Query<TReturn>(string storeProcedure, DynamicParameters dynamicParameters);
        TReturn QuerySingle<TReturn>(string storeProcedure, DynamicParameters dynamicParameters);
        bool Repair();
        void Rollback();
        bool Truncate();
        bool UnLock();
        bool Update(List<T> entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        void UpdateVoid(IEnumerable<T> entities);
        void UpdateVoid(T entity);
        //Extra DB Connections
        private static SqlConnection SqlConnection() => new SqlConnection(ConfigHelper.config.GetConnectionString("DefaultConnection"));

        private static IDbConnection CreateConnection()
        {
            var connection = SqlConnection();
            connection.Open();
            return connection;
        }

        private static IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
    }
}
