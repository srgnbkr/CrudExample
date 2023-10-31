﻿using Core.Application.Requests;
using Core.Application.Responses;
using crudExampleAPI.Application.Features.Products.Queries.GetAllProduct;
using crudExampleAPI.Application.Features.Products.Queries.GetByIdProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudExampleAPI.WebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery]GetAllProductQueryRequest request)
        {
            GetAllProductQueryRequest getAllProduct = new() { PageRequest = request.PageRequest };
            GetListResponse<GetAllProductQueryResponse> response = await Mediator.Send(getAllProduct);
            return Ok(response);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await Mediator.Send(request);
            return Ok(response);    
        }
    }
}
