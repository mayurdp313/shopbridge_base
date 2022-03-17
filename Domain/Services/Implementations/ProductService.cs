using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;

        private readonly IRepository _repository;
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _repository.GetAll<Category>();
            //throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _repository.GetAll<Product>();
            //throw new NotImplementedException();
        }
        public IEnumerable<Product> GetProduct(int id)
        {
            return _repository.GetProduct(id);
            //throw new NotImplementedException();
        }
        public IEnumerable<Product> GetProductByCategory(string categoryName)
        {
            return _repository.GetProductByCategory(categoryName);
        }
        public IEnumerable<Product> GetProductByCategory(string categoryName, int start, int pagesize)
        {
            return _repository.GetProductByCategory(categoryName,start,pagesize);
        }

        public IEnumerable<Category> GetCategory(int id)
        {
            return _repository.GetCategory(id);
            //throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            _repository.Delete(product);
            //throw new NotImplementedException();
        }
        public void DeleteCategory(Category category)
        {
            _repository.Delete(category);
            //throw new NotImplementedException();
        }
        public int? SaveCategory(Category category)
        {
            try
            {
                return _repository.Save(category);
            }
            catch (Exception ex)
            {
                logger.LogError("save category ", ex);
            }
            return null;
            //throw new NotImplementedException();
        }
        public int? SaveProduct(Product product)
        {
            try
            {
                return _repository.Save(product);
            }
            catch (Exception ex)
            {
                logger.LogError("save Product ", ex);
            }
            return null;
        }
        public int? UpdateCategory(Category category)
        {
            try
            {
                return _repository.Update(category);

            }
            catch (Exception ex)
            {
                logger.LogError("save category ", ex);

            }
            return null;
        }
        public int? UpdateProduct(Product product)
        {
            try
            {
                return _repository.Update(product);
            }
            catch (Exception ex)
            {
                logger.LogError("save Product ", ex);
            }
            return null;
        }
    }
}
