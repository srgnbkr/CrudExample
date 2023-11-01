using Core.CrossCuttingConcerns.Exceptions.Types;
using crudExampleAPI.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;

        public ProductBusinessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ProductNameShouldNotExistWhenCreating(string name) 
        {

            bool isExist = await _productRepository.AnyAsync(predicate: x => x.Name == name, enableTracking: false);
            if (isExist)
                throw new BusinessException("Product name already exist");
           
        }



    }
}
