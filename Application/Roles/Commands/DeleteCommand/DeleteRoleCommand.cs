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
    public class DeleteRoleCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class DeleteRoleCommandHanddler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IIdentityService _service;

        public DeleteRoleCommandHanddler(IIdentityService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteRole(request.Name);

            return Unit.Value;
        }
    }
}
