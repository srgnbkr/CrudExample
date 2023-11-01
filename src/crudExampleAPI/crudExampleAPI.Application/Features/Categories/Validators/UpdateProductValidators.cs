using crudExampleAPI.Application.Features.Products.Commands.UpdateProduct;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Validators
{
    public class UpdateProductValidators : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductValidators()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MinimumLength(3)
                .WithMessage("{PropertyName} must be at least 3 characters.")
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MinimumLength(3)
                .WithMessage("{PropertyName} must be at least 3 characters.")
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}
