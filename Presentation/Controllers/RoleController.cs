using Application.Roles.Commands.CreateRole;
using Application.Roles.Commands.DeleteRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagment.Presentation.Controllers;
using Application.RoleLists.Queries.GetRoles;
using Application.Roles.Commands.DeleteCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize]
    public class RoleController : ApiControllerBase
    {  
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<RoleListDto>> GetAll([FromQuery] GetRolesQuery query)
        {
            return await Mediator.Send(query);
        }

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
        public async Task<ActionResult> RemoveUserFromRole(string userId, string roleName)
        {
            await Mediator.Send(new RemoveUserRoleCommand { UserId = userId, RoleName = roleName });

            return NoContent();
        }

        //[HttpPost]
        //[Route("AddUserToRole")]
        //public async Task<ActionResult> AddUserToRole(string user, string roleName)
        //{
        //    await Mediator.Send(new AddUserRoleCommand { User = user, RoleName = roleName });

        //    return NoContent();
        //}

        //[HttpPut]
        //public async Task<ActionResult> Update(string name, UpdateRoleCommand command)
        //{
        //    if (name != command.Name)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);
        //    return NoContent();
        //}
    }
}
