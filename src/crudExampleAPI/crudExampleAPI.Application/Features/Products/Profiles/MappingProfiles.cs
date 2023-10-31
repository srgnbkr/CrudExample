using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using crudExampleAPI.Application.Features.Products.Queries.GetAllProduct;
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
            CreateMap<Product,GetAllProductResponse>().ReverseMap();
            CreateMap<IPaginate<Product>,GetListResponse<GetAllProductResponse>>().ReverseMap();
        }
    }
}
