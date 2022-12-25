using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllPaged(int limit, int offset);
        Task<IEnumerable<T>> GetAllPagedAsync(int limit, int offset);
        object Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void DeleteAll();
        //Extra
        TReturn QuerySingle<TReturn>(string storeProcedure, DynamicParameters dynamicParameters);

        IEnumerable<TReturn> Query<TReturn>(string storeProcedure, DynamicParameters dynamicParameters);

        int Execute(string storeProcedure, DynamicParameters dynamicParameters);
        T GetById<TParameter>(TParameter id) where TParameter : struct;

        IEnumerable<T> GetBy(Func<T, bool> predicate);
        //Async
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync<TParameter>(TParameter id) where TParameter : struct;

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        //Extra DB Connections
        private static SqlConnection SqlConnection()
        {
            return new SqlConnection("Data Source=127.0.0.1; Initial Catalog=TestDb; User Id=sa; Password=115411Myvz!");
        }

        private static IDbConnection CreateConnection()
        {
            var connection = SqlConnection();
            connection.Open();
            return connection;
        }

        private static IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
    }
}
