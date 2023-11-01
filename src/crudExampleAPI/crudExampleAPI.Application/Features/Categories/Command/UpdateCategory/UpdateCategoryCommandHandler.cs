using AutoMapper;
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

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(
                predicate: c => c.Id == request.Id,enableTracking:false,cancellationToken:cancellationToken);

            Category mappedCategory = _mapper.Map(request,destination:category!);
            Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);

            UpdateCategoryCommandResponse response = _mapper.Map<UpdateCategoryCommandResponse>(updatedCategory);
            return response;

        }
    }
}
