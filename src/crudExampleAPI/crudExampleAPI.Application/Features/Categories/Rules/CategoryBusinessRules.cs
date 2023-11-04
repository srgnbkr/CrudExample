using Core.CrossCuttingConcerns.Exceptions.Types;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameShouldNotExistWhenCreating(string name)
        {
            bool isExist = await _categoryRepository.AnyAsync(predicate: x => x.Name == name, enableTracking: false);
            if (isExist)
                throw new BusinessException("Category name already exist");
        }

        public Task CategoryShouldExistWhenSelected(Category category)
        {
            if (category == null)
                throw new BusinessException("Category not found");

            return Task.CompletedTask;
        }
    }
}
