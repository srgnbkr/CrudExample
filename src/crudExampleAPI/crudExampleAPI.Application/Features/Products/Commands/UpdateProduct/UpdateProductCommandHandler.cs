using AutoMapper;
using crudExampleAPI.Application.Features.Products.Rules;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product? product =  await _productRepository.GetAsync(
                predicate: p => p.Id == request.Id,
                enableTracking:false, 
                cancellationToken:cancellationToken);

            await _productBusinessRules.ProductShouldExistWhenSelected(product!);
            Product mappedProduct = _mapper.Map(request, destination: product!);

            Product updatedProduct = await _productRepository.UpdateAsync(mappedProduct);

            UpdateProductCommandResponse response = _mapper.Map<UpdateProductCommandResponse>(updatedProduct);
            return response;
        }
    }
}
