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
using Application.ResourceRoleLists.Commands.UpdateResourceRoleList;
using Application.ResourceRoleLists.Queries.GetResourceRoles;
using System.Security.Claims;
using Presentation.Filters;

namespace Presentation.Controllers
{
    [Authorize]
    public class RoleController : ApiControllerBase
    {  
        [HttpGet]
        [Route("GetAll")]
        [ServiceFilter(typeof(AuthorizeActionFilter))]
        public async Task<ActionResult<RoleListDto>> GetAll([FromQuery] GetRolesQuery query)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await Mediator.Send(query);
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizeActionFilter))]
        public async Task<ActionResult> Create(CreateRoleCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [ServiceFilter(typeof(AuthorizeActionFilter))]
        public async Task<ActionResult> Delete(DeleteRoleCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("RemoveUserFromRole")]
        [ServiceFilter(typeof(AuthorizeActionFilter))]
        public async Task<ActionResult> RemoveUserFromRole(string userId, string roleName)
        {
            await Mediator.Send(new RemoveUserRoleCommand { UserId = userId, RoleName = roleName });

            return NoContent();
        }

        [HttpPost]
        [Route("AddUserToRole")]
        [ServiceFilter(typeof(AuthorizeActionFilter))]
        public async Task<ActionResult> AddUserToRole(AddUserRoleCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut]
        [Route("UpdateResourceRole")]
        [ServiceFilter(typeof(AuthorizeActionFilter))]
        public async Task<ActionResult> UpdateResourceRole(UpdateResourceRoleCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        [Route("GetResourceRole")]
        public async Task<ActionResult<List<ResourceRoleDto>>> GetResourceRole([FromQuery] GetResourceRolesQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
