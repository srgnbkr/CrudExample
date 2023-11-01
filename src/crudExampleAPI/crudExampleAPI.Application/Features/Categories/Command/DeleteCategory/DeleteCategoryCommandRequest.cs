using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public int CategoryId { get; set; }
    }
}
