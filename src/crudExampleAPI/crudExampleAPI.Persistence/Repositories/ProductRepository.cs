using Core.Persistence.Repositories;
using crudExampleAPI.Application.Services.Repositories;
using crudExampleAPI.Domain.Entities;
using crudExampleAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Persistence.Repositories
{
    public class ProductRepository : EfRepositoryBase<Product, int, BaseDbContext>, IProductRepository
    {
        public ProductRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
