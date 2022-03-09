using SBM.Core;
using SBM.Core.DTOs;
using SBM.Core.Models;
using SBM.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetProductsWithCategoryAsync()
        {
            throw new ProductNotFoundException("ürün bulunamadı");

            var products = await productRepository.GetProductsWithCategoryAsync();
            var productDtos = new List<ProductDto>();
            products.ForEach(x => productDtos.Add(new ProductDto(x)));

            return productDtos;
        }
    }
}