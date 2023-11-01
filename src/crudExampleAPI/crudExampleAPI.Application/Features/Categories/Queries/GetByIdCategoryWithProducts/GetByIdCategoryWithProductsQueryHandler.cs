using AutoMapper;
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
        IMapper _mapper;

        public GetByIdCategoryWithProductsQueryHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetByIdCategoryWithProductsQueryResponse> Handle(GetByIdCategoryWithProductsQueryRequest request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository
                .GetAsync(predicate:x => x.Id == request.CategoryId,include:y => y.Include(x => x.Products));

            GetByIdCategoryWithProductsQueryResponse response = new()
            {
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
