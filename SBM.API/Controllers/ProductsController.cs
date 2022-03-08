using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBM.Core.Models;
using SBM.Repository;

namespace SBM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Save()
        {
            var category = new Category() { Name = "Kalemler" };

            category.Products.Add(new() { Name = "kalem 1", Price = 200, Stock = 300, Barcode = "abc", Number = 1 });

            var product = new Product() { Name = "Kitap 1", Price = 200, Stock = 300, Barcode = "abc", Number = 1 };

            product.Category = new Category() { Name = "Kitaplar" };

            _context.Products.Add(product);
            _context.Categories.Add(category);

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("EagerLoading")]
        public IActionResult EagerLoading()
        {
            var categoryWithProducts = _context.Categories.Include(x => x.Products).ToList();

            var productsWithCategory = _context.Products.Include(x => x.Category).ToList();

            return Ok();
        }

        [HttpGet("ExplicitLoading")]
        public IActionResult ExplicitLoading()
        {
            var product = _context.Products.First();
            _context.Entry(product).Reference(x => x.Category).Load();
            var category = _context.Categories.First();
            //  var products = _context.Products.Where(x => x.CategoryId == category.Id).ToList();

            _context.Entry(category).Collection(x => x.Products).Query().Where(x => x.Stock > 100).Load();

            return Ok();
        }

        [HttpGet("LazyLoading")]
        public IActionResult LazyLoading()
        {
            var categories = _context.Categories.ToList();
            // N+1  problem
            categories.ForEach(x =>
            {
                var veri = "abc";
                var products = x.Products;
            });

            return Ok();
        }

        [HttpGet("State")]
        public IActionResult State()
        {
            //  var category = _context.Categories.First();

            //var OneState = _context.Entry(category).State;

            // category.Name = "Kalemler 10";

            //var TwoState = _context.Entry(category).State;

            //_context.SaveChanges();

            //var ThreeState = _context.Entry(category).State;
            var category = new Category() { Id = 1, Name = "Kitaplar 10" };

            var state = _context.Entry(category).State;

            _context.Categories.Update(category);
            var state2 = _context.Entry(category).State;

            _context.SaveChanges();
            return Ok();
        }
    }
}