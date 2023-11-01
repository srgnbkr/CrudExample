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

namespace crudExampleAPI.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,IMapper mapper,CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryNameShouldNotExistWhenCreating(request.Name);
            Category mappedCategory = _mapper.Map<Category>(request);
            Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
            CreateCategoryCommandResponse response = _mapper.Map<CreateCategoryCommandResponse>(createdCategory);
            return response;
        }
    }
}
