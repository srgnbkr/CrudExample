﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crudExampleAPI.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator =>
        _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");

        private IMediator? _mediator;
    }
}