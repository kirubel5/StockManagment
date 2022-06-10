using Application.Authentication.Commands.Login;
using Application.Common.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> LogUserInAsync(LoginCommand command)
            => Ok(await Mediator.Send(command));
    }
}
