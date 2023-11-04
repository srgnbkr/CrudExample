using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using crudExampleAPI.Application.Features.Categories.Command.CreateCategory;
using crudExampleAPI.Application.Features.Categories.Command.DeleteCategory;
using crudExampleAPI.Application.Features.Categories.Command.UpdateCategory;
using crudExampleAPI.Application.Features.Categories.Queries.GetAllCategory;
using crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategory;
using crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategoryWithProducts;
using crudExampleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, GetAllCategoryQueryResponse>().ReverseMap();
            CreateMap<IPaginate<Category>, GetListResponse<GetAllCategoryQueryResponse>>().ReverseMap();

            CreateMap<Category, GetByIdCategoryQueryResponse>().ReverseMap();

            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandResponse>().ReverseMap();

            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandResponse>().ReverseMap();

            CreateMap<Category, DeleteCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommandResponse>().ReverseMap();

        }

    }
}
