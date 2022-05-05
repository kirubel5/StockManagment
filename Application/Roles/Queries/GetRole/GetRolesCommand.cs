using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Queries.GetRole
{
    public class GetRolesCommand : IRequest
    {

    }

    public class CreateRoleCommandHanddler : IRequestHandler<GetRolesCommand>
    {
        private readonly IIdentityService _service;
        private readonly IMapper _mapper;

        public CreateRoleCommandHanddler(IIdentityService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<RoleListDto> Handle(GetRolesCommand request, CancellationToken cancellationToken)
        {
            //try
            //{
            //    return new RoleListDto
            //    {
            //        Lists = await _service.GetRoles()
            //    };
            //}
            //catch (ArgumentNullException)
            //{
            //    throw;
            //}
            return null;
        }

        Task<Unit> IRequestHandler<GetRolesCommand, Unit>.Handle(GetRolesCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
