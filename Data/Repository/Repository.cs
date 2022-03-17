using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly Shopbridge_Context dbcontext;

        public Repository(Shopbridge_Context _dbcontext)
        {
            this.dbcontext = _dbcontext;
        }

        public IQueryable<T> AsQueryable<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            throw new NotImplementedException();
        }
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return dbcontext.Set<T>().ToList();
        }

        public IEnumerable<Product> GetProduct(int id)
        {
            return dbcontext.Products.Include(q => q.category).Where(q => q.Product_Id == id).ToList();
        }

        public IEnumerable<Product> GetProductByCategory(string categoryName)
        {

            return dbcontext.Products.Include(q => q.category).Where(q => q.category.CategoryName == categoryName).ToList();

        }

        public IEnumerable<Product> GetProductByCategory(string categoryName,int start,int pagesize)
        {

            var products= dbcontext.Products.Include(q => q.category).Where(q => q.category.CategoryName == categoryName).ToList();
            return products.Skip((start - 1) * pagesize).Take(pagesize).ToList();
        }

        public IEnumerable<Category> GetCategory(int id)
        {
            return dbcontext.Categories.Where(q => q.CategoryId == id).ToList();
        }

        public void Delete<T>(T t) where T : class
        {
            dbcontext.Set<T>().Remove(t);
            dbcontext.SaveChanges();
        }

        public int Save<T>(T t) where T : class
        {
            dbcontext.Add(t);
            return dbcontext.SaveChanges();

        }
        public int Update<T>(T t) where T : class
        {
            dbcontext.Update(t);
            return dbcontext.SaveChanges();

        }
    }
}
