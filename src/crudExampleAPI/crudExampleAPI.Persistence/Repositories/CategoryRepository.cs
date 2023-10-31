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
    public class CategoryRepository : EfRepositoryBase<Category, int, BaseDbContext>, ICategoryRepository
    {
        public CategoryRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
