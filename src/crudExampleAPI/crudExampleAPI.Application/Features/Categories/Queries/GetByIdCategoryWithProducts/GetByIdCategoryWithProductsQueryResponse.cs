using crudExampleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategoryWithProducts
{
    public class GetByIdCategoryWithProductsQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductListForCategoryDto> Products { get; set; }

    }

    public class ProductListForCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    
    
}
