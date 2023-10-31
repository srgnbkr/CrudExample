using Core.Persistence.Paging;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Services.ProductsService
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IPaginate<Product>?> GetListProductAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IPaginate<Product> productList = await _productRepository.GetListAsync(predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken);

            return productList;
        }
    }
}
