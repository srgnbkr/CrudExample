using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<GetListResponse<GetAllCategoryQueryResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public GetAllCategoryQueryRequest()
        {
            PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
        }

        public GetAllCategoryQueryRequest(PageRequest pageRequest)
        {
            PageRequest = pageRequest;
        }
    }
}
   
