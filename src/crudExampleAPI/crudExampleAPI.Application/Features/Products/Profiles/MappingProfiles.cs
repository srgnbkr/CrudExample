using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using crudExampleAPI.Application.Features.Products.Commands.CreateProduct;
using crudExampleAPI.Application.Features.Products.Commands.DeleteProduct;
using crudExampleAPI.Application.Features.Products.Commands.UpdateProduct;
using crudExampleAPI.Application.Features.Products.Queries.GetAllProduct;
using crudExampleAPI.Application.Features.Products.Queries.GetByIdProduct;
using crudExampleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,GetAllProductQueryResponse>().ReverseMap();
            CreateMap<IPaginate<Product>,GetListResponse<GetAllProductQueryResponse>>().ReverseMap();

            CreateMap<Product, GetByIdProductQueryResponse>().ReverseMap();

            CreateMap<Product, UpdateProductCommandResponse>().ReverseMap();
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();

            CreateMap<Product, CreateProductCommandResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();

            CreateMap<Product, DeleteProductCommandResponse>().ReverseMap();
            CreateMap<Product, DeleteProductCommandRequest>().ReverseMap();
            
        }
    }
}
