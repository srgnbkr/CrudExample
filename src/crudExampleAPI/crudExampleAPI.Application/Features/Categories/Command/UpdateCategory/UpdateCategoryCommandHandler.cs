using AutoMapper;
using crudExampleAPI.Application.Features.Categories.Rules;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(
                predicate: c => c.Id == request.Id,enableTracking:false,cancellationToken:cancellationToken);

            await _categoryBusinessRules.CategoryShouldExistWhenSelected(category!);    

            Category mappedCategory = _mapper.Map(request,destination:category!);
            Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);

            UpdateCategoryCommandResponse response = _mapper.Map<UpdateCategoryCommandResponse>(updatedCategory);
            return response;

        }
    }
}
