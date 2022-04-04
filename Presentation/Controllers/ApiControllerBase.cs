﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace StockManagment.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

         protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
      
    }
}
