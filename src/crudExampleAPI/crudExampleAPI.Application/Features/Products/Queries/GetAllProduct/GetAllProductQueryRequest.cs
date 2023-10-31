using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<GetListResponse<GetAllProductQueryResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public GetAllProductQueryRequest()
        {
            PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
        }

        public GetAllProductQueryRequest(PageRequest pageRequest)
        {
            PageRequest = pageRequest;
        }
    }
}
