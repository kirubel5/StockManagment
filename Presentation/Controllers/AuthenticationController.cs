using Application.Authentication.Commands.Login;
using Application.Authentication.Commands.Register;
using Application.Common.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Presentation.Controllers;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> LogUserInAsync(LoginCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<bool>> RegisterUser(RegisterCommand command)
            => Ok(await Mediator.Send(command));

      
    }
}
