using Core.Persistence.Repositories;
using crudExampleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Services.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product,int>
    {
    }
}
