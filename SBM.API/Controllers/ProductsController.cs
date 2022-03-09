using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBM.Core;
using SBM.Core.DTOs;
using SBM.Core.Models;

namespace SBM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService genericServiceProduct)
        {
            _productService = genericServiceProduct;
        }

        /// <summary>
        /// Tüm ürünleri getirir.
        /// </summary>
        ///  <remarks>
        /// Product tablosundan tüm  isDeleted=false işaretlenmiş dataları getirir.
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.Where(x => x.Id > 0).ToListAsync();

            var productDtos = new List<ProductDto>();

            products.ForEach(x => productDtos.Add(new ProductDto(x)));

            return Ok(productDtos);
        }

        /// <summary>
        /// tüm ürümler ile beraber category bilgisini getirir.
        /// </summary>
        /// <remarks>
        /// Bu ürün kaydedildiğini external system için kayıt oluşur
        /// </remarks>
        /// <response code='200'>Ürün veritabanından başarılı bir şekilde alınır.</response>
        /// <response code='404'>İstenen ürün veritabanında yoktur.</response>
        /// <returns></returns>
        [HttpGet("ProductsWithCategory")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ProductsWithCategory()
        {
            return Ok(await _productService.GetProductsWithCategoryAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            throw new Exception("veritabanı bağlantısı");
            var newProduct = new Product() { Name = productDto.Name, Price = productDto.Price, Stock = productDto.Stock, Barcode = Guid.NewGuid().ToString(), CategoryId = productDto.CategoryId };
            var product = await _productService.AddAsync(newProduct);

            return Ok(ProductDto.ProductToDto(product));
        }
    }
}