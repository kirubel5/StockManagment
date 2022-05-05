using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Commands.CreateCommand
{
    public class AddUserRoleCommand : IRequest
    {
        public string RoleName { get; set; }
        public string User { get; set; }
    }

    public class AddUserRoleCommandHanddler : IRequestHandler<AddUserRoleCommand>
    {
        private readonly IIdentityService _service;

        public AddUserRoleCommandHanddler(IIdentityService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _service.AddUserToRole(request.User, request.RoleName);

            return Unit.Value;
        }
    }
}
