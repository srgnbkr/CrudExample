using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using crudExampleAPI.Application.Services.ProductsService;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetListResponse<GetAllProductQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public GetAllProductQueryHandler(IProductRepository productRepository, IProductService productService, IMapper mapper)
        {
            _productRepository = productRepository;
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            GetListResponse<GetAllProductQueryResponse> response = _mapper.Map<GetListResponse<GetAllProductQueryResponse>>(products);

            return response;
        }
    }
}







