using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository
    {
        IQueryable<T> AsQueryable<T>() where T : class;
        IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class;
        IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class;
        IEnumerable<T> Get<T>() where T : class;

        /// <summary>
        /// Get all records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>() where T : class;

        IEnumerable<Product> GetProduct(int id);

        IEnumerable<Product> GetProductByCategory(string categoryName);

        IEnumerable<Product> GetProductByCategory(string categoryName, int start, int pagesize);

        IEnumerable<Category> GetCategory(int id);

        void Delete<T>(T t) where T : class;

        int Save<T>(T t) where T : class;

        int Update<T>(T t) where T : class;
    }
}
