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
    public class GetAllProductRequest : IRequest<GetListResponse<GetAllProductResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public GetAllProductRequest()
        {
            PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
        }

        public GetAllProductRequest(PageRequest pageRequest)
        {
            PageRequest = pageRequest;
        }
    }
}
