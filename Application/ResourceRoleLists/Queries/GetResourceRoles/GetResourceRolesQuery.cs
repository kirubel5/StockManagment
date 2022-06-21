using Application.Common.Interfaces;
using Application.ResourceRoleLists.Commands.UpdateResourceRoleList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ResourceRoleLists.Queries.GetResourceRoles
{
    public class GetResourceRolesQuery : IRequest<List<ResourceRoleDto>>
    {
        
    }

    public class GetResourceRolesQueryHandler : IRequestHandler<GetResourceRolesQuery, List<ResourceRoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _service;

        public GetResourceRolesQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        public async Task<List<ResourceRoleDto>> Handle(GetResourceRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<ResourceRole> resourceRoleList = new List<ResourceRole>();
                List<ResourceRoleDto> resourceRoles = new List<ResourceRoleDto>();
                
                resourceRoleList = await _context.ResourceRoles
                    .ToListAsync(cancellationToken);

                foreach (var item in resourceRoleList)
                {
                    resourceRoles.Add(new ResourceRoleDto
                    {
                        RoleName = await _service?.GetRoleNameById(item.RoleId),
                        ResourceName = _context.Resources.Where(x => x.Id.ToString() == item.ResourceId)?.FirstOrDefault()?.Name
                    });
                }

                return resourceRoles;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
