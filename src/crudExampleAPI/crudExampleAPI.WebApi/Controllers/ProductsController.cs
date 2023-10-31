using Core.Application.Responses;
using crudExampleAPI.Application.Features.Products.Queries.GetAllProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudExampleAPI.WebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery]GetAllProductRequest request)
        {
            GetAllProductRequest getAllProduct = new() { PageRequest = request.PageRequest };
            GetListResponse<GetAllProductResponse> response = await Mediator.Send(getAllProduct);
            return Ok(response);

        }
    }
}
