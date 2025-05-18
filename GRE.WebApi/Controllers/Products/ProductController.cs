using GRE.Application.Interfaces.Services.Product;
using GRE.Shared.DTOs.Product;
using GRE.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRE.WebApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productService.AddProductAsync(product));
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productService.UpdateProductAsync(product));
        }
        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> DeleteProduct([FromBody] int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productService.DeleteProductAsync(productId));
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProducts([FromBody] FilterModel filterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productService.GetAllProducts(filterModel));
        }
    }
}
