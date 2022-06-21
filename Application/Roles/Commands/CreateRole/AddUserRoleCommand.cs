using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Commands.CreateRole
{
    public class AddUserRoleCommand : IRequest
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }

    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand>
    {
        private readonly IIdentityService _service;

        public AddUserRoleCommandHandler(IIdentityService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
             await _service.AddUserToRole(request.UserId, request.RoleName);

            return Unit.Value;
        }
    }
}
