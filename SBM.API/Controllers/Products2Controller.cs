using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBM.Core.DTOs;
using SBM.Core.Models;

namespace SBM.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class Products2Controller : ControllerBase
    //{
    //    private static List<Product> Products = new List<Product>() {
    //    new() { Id=1, Name="Kalem 1", Price=100, Stock=200 },
    //    new() { Id=1, Name="Kalem 1", Price=100, Stock=200 }};

    //    [HttpGet]
    //    public IActionResult GetProducts()
    //    {
    //        return Ok(Products);
    //    }

    //    [HttpGet("{id}")]
    //    public IActionResult GetProduct(int id)
    //    {
    //        var hasProduct = Products.FirstOrDefault(x => x.Id == id);

    //        if (hasProduct == null)
    //            return NotFound();

    //        return Ok(hasProduct);
    //    }

    //    [HttpGet("ProductsWithPages/{page}/{pageSize}")]
    //    public IActionResult GetProductsWitPage([FromRoute] ReqeustPageDto request)
    //    {
    //        //  1 10 => ilk 10 data
    //        //  2 10 => ikinci 10
    //        var products = Products.Skip((request.Page - 1) * request.PageSize).Take(10).ToList();

    //        return Ok(products);
    //    }

    //    [HttpPost("/Work")]
    //    public IActionResult Work(List<Product> products)
    //    {
    //        throw new Exception("bir hata oldu");
    //        return Ok(products);
    //    }

    //    [HttpPost]
    //    public IActionResult SaveProduct(Product product)
    //    {
    //        Products.Add(product);
    //        return Created("", product);
    //    }

    //    [HttpPost("SaveProduct10/{id}")]
    //    public IActionResult SaveProduct10(Product product, [FromRoute] int id)
    //    {
    //        Products.Add(product);
    //        return Created("", product);
    //    }

    //    [HttpGet("SaveProduct2")]
    //    public IActionResult SaveProduct2([FromQuery] Product product)
    //    {
    //        Products.Add(product);
    //        return Created("", product);
    //    }

    //    [HttpPost("SaveProduct3")]
    //    public IActionResult SaveProduct3([FromHeader] string name, [FromHeader] decimal price)
    //    {
    //        return Ok();
    //    }

    //    [HttpPost("SaveProduct4")]
    //    public IActionResult SaveProduct4([FromHeader] Product product)
    //    {
    //        return Ok();
    //    }

    //    [HttpPost("SaveProduct5")]
    //    public IActionResult SaveProduct5([FromBody] string name)
    //    {
    //        return Ok();
    //    }

    //    [HttpPost("SaveProduct6")]
    //    public IActionResult SaveProduct6([FromBody] int[] number)
    //    {
    //        return Ok(String.Join(",", number));
    //    }

    //    [HttpPost("SaveProduct7/{id}/{name}/{price}/{stock}")]
    //    public IActionResult SaveProduct7([FromRoute] Product product)
    //    {
    //        return Ok();
    //    }

    //    [HttpPut]
    //    public IActionResult UpdateProduct(Product product)
    //    {
    //        // update yapıldı

    //        return NoContent();
    //    }

    //    [HttpDelete("{id}")]
    //    public IActionResult DeleteProduct(int id)
    //    {
    //        //Silme işlemi yapıldı
    //        return NoContent();
    //    }
    //}
}