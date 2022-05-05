using Application.Roles.Commands.CreateCommand;
using Application.Roles.Commands.DeleteCommand;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class RoleController : ApiControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<ConsigneeList>> Get([FromQuery] GetConsigneesQuery query)
        //{
        //    return await Mediator.Send(query);
        //}

        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string name)
        {
            await Mediator.Send(new DeleteRoleCommand { Name = name });

            return NoContent();
        }

        [HttpDelete]
        [Route("RemoveUserFromRole")]
        public async Task<ActionResult> RemoveUserFromRole(string user, string roleName)
        {
            await Mediator.Send(new RemoveUserRoleCommand { User = user, RoleName = roleName });

            return NoContent();
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<ActionResult> AddUserToRole(string user, string roleName)
        {
            await Mediator.Send(new AddUserRoleCommand { User = user, RoleName = roleName });

            return NoContent();
        }
    }
}
