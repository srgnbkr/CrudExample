using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using crudExampleAPI.Application.Features.Categories.Rules;
using crudExampleAPI.Application.Features.Products.Rules;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategoryWithProducts
{
    public class GetByIdCategoryWithProductsQueryHandler : IRequestHandler<GetByIdCategoryWithProductsQueryRequest, GetByIdCategoryWithProductsQueryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly ProductBusinessRules _productBusinessRules;

        public GetByIdCategoryWithProductsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules, ProductBusinessRules productBusinessRules, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _productBusinessRules = productBusinessRules;
            _productRepository = productRepository;
        }

        public async Task<GetByIdCategoryWithProductsQueryResponse> Handle(GetByIdCategoryWithProductsQueryRequest request, CancellationToken cancellationToken)
        {

            //TODO:Burada ilgili kategori yoksa kategori bulunamadı mesajı, kategori varsa da ürünlerini getirme işlemi yapılacak.
            //TODO: Ama kateogri olup kateogrilere ait ürünler olmayabilir. Bu durumda da ürün bulunamadı mesajı dönecek.
            Category? category = await _categoryRepository
                .GetAsync(predicate:x => x.Id == request.CategoryId,include:y => y.Include(x => x.Products));

            await _categoryBusinessRules.CategoryShouldExistWhenSelected(category!);

            //TODO : Burayı productbusinessrules içine almak lazım.
           await _productBusinessRules.ProductListShouldExistWhenSelected(category.Products.ToList());






            GetByIdCategoryWithProductsQueryResponse response = new()
            {
                //TODO: Bu kısmı automapper ile yapmak lazım.
            

                Products = category.Products.Select(x => new ProductListForCategoryDto
                {
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).ToList(),
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            

            return response;













        }
    }
}
