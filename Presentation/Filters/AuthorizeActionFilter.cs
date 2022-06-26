using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Filters
{
    public class AuthorizeActionFilter : IAsyncActionFilter
    {
        private readonly ICurrentUserService _service;
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public AuthorizeActionFilter(ICurrentUserService service, IApplicationDbContext context, IIdentityService identityService)
        {
            _service = service;
            _context = context;
            _identityService = identityService;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string userRoleName = _service.UserRole;
            var (result, controllerName) = Helper.GetControllerName(context.Controller.ToString());

            if (!result)
            {
                context.Result = new BadRequestResult();
            }
            else
            {
                List<ResourceRole> resources = await _context.ResourceRoles.ToListAsync();
                List<string> resourcesNamesAssociatedWithThisUserRole = new();

                string userRoleId = await _identityService?.GetRoleIdByName(userRoleName);

                foreach (ResourceRole item in resources)
                {
                    if (userRoleId == item.RoleId)
                    {
                        resourcesNamesAssociatedWithThisUserRole.Add
                            (_context.Resources
                            .Where(x => x.Id.ToString() == item.ResourceId)?
                            .FirstOrDefault()?.Name);
                    }
                }

                foreach (var item in resourcesNamesAssociatedWithThisUserRole)
                {
                    if (controllerName == item)
                    {
                        await next();
                        return;
                    }
                }

                context.Result = new UnauthorizedObjectResult(context.Result);
            }
        }
    }
}
