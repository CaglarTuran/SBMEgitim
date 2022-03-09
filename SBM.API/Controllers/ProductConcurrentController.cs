using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBM.Core.Models;
using SBM.Repository;
using System.Text.Json;

namespace SBM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductConcurrentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductConcurrentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
            {
                var products = _context.Products.Where(x => x.Id > 10 && x.Id < 20).ToList();
            }

            var hasProduct = await _context.Products.FindAsync(product.Id);

            hasProduct.Name = product.Name;
            hasProduct.Price = product.Price;

            _context.Database.ExecuteSqlRaw("update Products set Name='kitap 10002' where id=1");

            try
            {
                _context.Update(hasProduct);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var databaseEntry = await exceptionEntry.GetDatabaseValuesAsync();

                if (databaseEntry == null)
                {
                    return BadRequest("bu data silinmiş");
                }
                else
                {
                    var databaseValueProduct = databaseEntry.ToObject() as Product;

                    return BadRequest($"bu ürün başka bir kullanıcı tarafından güncelenmiştir.{JsonSerializer.Serialize(databaseValueProduct)}");
                }

                throw;
            }

            return Ok();
        }
    }
}