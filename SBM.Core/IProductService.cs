using SBM.Core.DTOs;
using SBM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Core
{
    public interface IProductService : IGenericService<Product>
    {
        Task<List<ProductDto>> GetProductsWithCategoryAsync();
    }
}