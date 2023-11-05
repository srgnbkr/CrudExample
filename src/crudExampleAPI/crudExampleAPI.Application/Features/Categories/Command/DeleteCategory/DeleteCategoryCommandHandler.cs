using AutoMapper;
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

namespace crudExampleAPI.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly ProductBusinessRules _productBusinessRules;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules, ProductBusinessRules productBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(predicate:x => x.Id == request.CategoryId,include:x =>x.Include(y => y.Products),cancellationToken:cancellationToken);

            await _categoryBusinessRules.CategoryShouldExistWhenSelected(category!);
            await _productBusinessRules.ProductListShouldNotExistWhenSelected(category!.Products.ToList());
            await _categoryRepository.DeleteAsync(category!);
            DeleteCategoryCommandResponse response = _mapper.Map<DeleteCategoryCommandResponse>(category);
            return response;

        }
    }
}
