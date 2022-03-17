using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct();
        IEnumerable<Product> GetProduct(int id);
        IEnumerable<Product> GetProductByCategory(string categoryName);
        IEnumerable<Product> GetProductByCategory(string categoryName, int start, int pagesize);
        IEnumerable<Category> GetAllCategory();

        IEnumerable<Category> GetCategory(int id);

        void DeleteProduct(Product product);
        void DeleteCategory(Category category);
        int? UpdateProduct(Product t);

        int? UpdateCategory(Category t);

        int? SaveProduct(Product t);

        int? SaveCategory(Category t);


    }
}
