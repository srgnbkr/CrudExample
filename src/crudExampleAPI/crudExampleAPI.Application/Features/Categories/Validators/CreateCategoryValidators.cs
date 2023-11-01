using crudExampleAPI.Application.Features.Categories.Command.CreateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Validators
{
    public class CreateCategoryValidators : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryValidators()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            
            RuleFor(c => c.Description).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}
