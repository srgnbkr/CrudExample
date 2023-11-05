using Core.Application.Responses;
using crudExampleAPI.Application.Features.Categories.Command.CreateCategory;
using crudExampleAPI.Application.Features.Categories.Command.DeleteCategory;
using crudExampleAPI.Application.Features.Categories.Command.UpdateCategory;
using crudExampleAPI.Application.Features.Categories.Queries.GetAllCategory;
using crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategory;
using crudExampleAPI.Application.Features.Categories.Queries.GetByIdCategoryWithProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudExampleAPI.WebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllCategory([FromQuery]GetAllCategoryQueryRequest request)
        {
            GetAllCategoryQueryRequest getAllCategoryQueryRequest = new() { PageRequest = request.PageRequest };
            GetListResponse<GetAllCategoryQueryResponse> response = await Mediator.Send(getAllCategoryQueryRequest);

            return Ok(response);
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetByIdCategory([FromRoute] GetByIdCategoryQueryRequest request)
        {
            GetByIdCategoryQueryResponse response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("With-Products/{CategoryId}")]
        public async Task<IActionResult> GetByIdCategoryWithProducts([FromRoute] GetByIdCategoryWithProductsQueryRequest request)
        {
            GetByIdCategoryWithProductsQueryResponse response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            
            UpdateCategoryCommandResponse response = await Mediator.Send(request);
            return Ok(response);
            
        }

        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest request)
        {
            DeleteCategoryCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
