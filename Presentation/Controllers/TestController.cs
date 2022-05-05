using Microsoft.AspNetCore.Mvc;
using StockManagment.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class TestController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var claims = User.Claims.Select(x => $"{x.Type}:{x.Value}");
            return Ok(new
            {
                message = "Hello",
                claims = claims.ToArray()
            });
        }
    }
}
