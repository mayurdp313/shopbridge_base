using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<CategoryController> logger;
        public CategoryController(IProductService _productService)
        {
            this.productService = _productService;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            var obj = productService.GetAllCategory();
            return (obj.Count() == 0) ? new NoContentResult() : new OkObjectResult(obj);


        }

        /// <summary>
        /// Get single category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var obj = productService.GetCategory(id);
            return (obj.Count() == 0) ? new NoContentResult() : new OkObjectResult(obj);
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] Category category)
        {
            var obj = productService.UpdateCategory(category);
            return (obj == null) ? new BadRequestResult() : new OkObjectResult("Category is updated");
        }

        /// <summary>
        /// save category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromBody]Category category)
        {
            var obj = productService.SaveCategory(category);
            return (obj == null) ? new BadRequestResult() : new OkObjectResult("Category is inserted");
        }

        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var obj = productService.GetCategory(id);
            if (obj.Count() == 0)
                return new NoContentResult();
            productService.DeleteCategory(obj.FirstOrDefault());
            return new OkObjectResult("Delete Success");
        }


    }
}
