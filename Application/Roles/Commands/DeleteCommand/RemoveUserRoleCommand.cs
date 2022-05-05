using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Commands.DeleteCommand
{
    public class RemoveUserRoleCommand :IRequest
    {
        public string RoleName { get; set; }
        public string User { get; set; }
    }

    public class DeleteUserRoleCommandHanddler : IRequestHandler<RemoveUserRoleCommand>
    {
        private readonly IIdentityService _service;

        public DeleteUserRoleCommandHanddler(IIdentityService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _service.RemoveUserFromRole(request.User, request.RoleName);

            return Unit.Value;
        }
    }
}
