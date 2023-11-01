using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using crudExampleAPI.Application.Features.Products.Queries.GetAllProduct;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetListResponse<GetAllCategoryQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetListResponse<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Category> categories = await _categoryRepository.GetListAsync(index:        request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetAllCategoryQueryResponse> response = _mapper.Map<GetListResponse<GetAllCategoryQueryResponse>>(categories);

            return response;
        }
    }
}
