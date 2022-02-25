using ClassLibrary;
using ClassLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productRepository;

        public ProductController(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName(nameof(GetProductsAsync))]
        public IEnumerable<Product> GetProductsAsync()
        {
            return _productRepository.GetProducts();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName(nameof(GetProductById))]
        public ActionResult<Product> GetProductById(int id)
        {
            var productByID = _productRepository.GetProductById(id);
            if (productByID == null)
            {
                return NotFound();
            }
            return productByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateProductAsync))]
        public async Task<ActionResult<Product>> CreateProductAsync(Product product)
        {
            await _productRepository.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateProduct))]

        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productRepository.UpdateProductAsync(product);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteProduct))]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product =  _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteProductAsync(product);

            return NoContent();
        }

    }
}
