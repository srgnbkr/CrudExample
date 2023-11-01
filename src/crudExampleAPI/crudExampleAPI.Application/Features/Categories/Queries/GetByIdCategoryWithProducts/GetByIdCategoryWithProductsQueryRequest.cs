using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategoryWithProducts
{
    public class GetByIdCategoryWithProductsQueryRequest : IRequest<GetByIdCategoryWithProductsQueryResponse>
    {
        public int CategoryId { get; set; }
    }
}
