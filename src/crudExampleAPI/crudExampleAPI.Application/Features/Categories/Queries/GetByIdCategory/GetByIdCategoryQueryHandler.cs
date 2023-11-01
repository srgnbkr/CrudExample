using AutoMapper;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        public readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.CategoryId, cancellationToken: cancellationToken);

            GetByIdCategoryQueryResponse response = _mapper.Map<GetByIdCategoryQueryResponse>(category);
            return response;
        }
    }
}
