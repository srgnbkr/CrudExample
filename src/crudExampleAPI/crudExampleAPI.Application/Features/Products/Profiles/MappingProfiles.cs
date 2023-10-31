using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
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
        }
    }
}
