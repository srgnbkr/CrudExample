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

namespace crudExampleAPI.Application.Features.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly Mapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, ProductBusinessRules productBusinessRules, Mapper mapper)
        {
            _productRepository = productRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.ProductId,cancellationToken:cancellationToken);
            
            await _productBusinessRules.ProductShouldExistWhenSelected(product);
            await _productRepository.DeleteAsync(product);
            DeleteProductCommandResponse response = _mapper.Map<DeleteProductCommandResponse>(product);
            return response;
             
        }
    }

}
