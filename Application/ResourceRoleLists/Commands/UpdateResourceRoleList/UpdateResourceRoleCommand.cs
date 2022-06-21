﻿using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ResourceRoleLists.Commands.UpdateResourceRoleList
{
    public class UpdateResourceRoleCommand : IRequest
    {
        public List<ResourceRoleDto> List = new List<ResourceRoleDto>();
    }

    public class UpdateResourceRoleCommandHandler : IRequestHandler<UpdateResourceRoleCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _service;

        public UpdateResourceRoleCommandHandler(IApplicationDbContext context, IIdentityService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<Unit> Handle(UpdateResourceRoleCommand request, CancellationToken cancellationToken)
        {
            List<ResourceRole> resourceRoles = new List<ResourceRole>();

            try
            {
                foreach (var item in request.List)
                {
                    resourceRoles.Add(new ResourceRole
                    {
                        RoleId = await _service.GetRoleId(item.RoleName),
                        ResourceId = _context.Resources.Where(x => x.Name == item.ResourceName).FirstOrDefault().Id.ToString()
                    });
                }

                await _context.ResourceRoles.AddRangeAsync(resourceRoles);
            }
            catch (Exception)
            {
                throw;
            }

            return Unit.Value;
        }
    }
}
