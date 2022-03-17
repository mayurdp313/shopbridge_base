using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }


        /// <summary>
        /// TO get all product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var obj =  productService.GetAllProduct();
            return (obj.Count() == 0) ? new NoContentResult() :new  OkObjectResult(obj);


        }

        /// <summary>
        /// TO get single product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var obj = productService.GetProduct(id);
            return (obj.Count() == 0) ? new NoContentResult() : new OkObjectResult(obj);
        }

        /// <summary>
        /// Get product list matching category name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [HttpGet("GetProductByCategory/{categoryName}")]
        public async Task<ActionResult<Product>> GetProductByCategory(string categoryName)
        {
            var obj = productService.GetProductByCategory(categoryName);
            return (obj.Count() == 0) ? new NoContentResult() : new OkObjectResult(obj);
        }

        /// <summary>
        /// Get product by category paging
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="pageno"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet("GetProductByCategory/{categoryName},{pageno},{pagesize}")]
        public async Task<ActionResult<Product>> GetProductByCategory(string categoryName,int pageno,int pagesize)
        {
            var obj = productService.GetProductByCategory(categoryName, pageno, pagesize);
            return (obj.Count() == 0) ? new NoContentResult() : new OkObjectResult(obj);
        }

        /// <summary>
        /// update product 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            var obj = productService.UpdateProduct(product);
            return (obj == null) ? new BadRequestResult() : new OkObjectResult("Product is updated");
        }


        /// <summary>
        /// save new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var obj = productService.SaveProduct(product);
            return (obj == null) ?  new BadRequestResult() : new OkObjectResult("Product is inserted");
        }

        /// <summary>
        /// delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var obj = productService.GetProduct(id);
            if (obj.Count() == 0)
               return new NoContentResult();
            productService.DeleteProduct(obj.FirstOrDefault());
            return new OkObjectResult("Delete Success");
        }

        private bool ProductExists(int id)
        {
            return false;
        }
    }
}
