using SBM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; } = new();

        public ProductDto()
        {
        }

        public ProductDto(Product p) => (Id, Name, Price, Stock, Category.Id, Category.Name) = (p.Id, p.Name, p.Price, p.Stock, p.Category.Id, p.Category.Name);

        public static ProductDto ProductToDto(Product p)
        {
            return new ProductDto() { Id = p.Id, Name = p.Name, Price = p.Price, Stock = p.Stock, CategoryId = p.CategoryId };
        }
    }
}