using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
