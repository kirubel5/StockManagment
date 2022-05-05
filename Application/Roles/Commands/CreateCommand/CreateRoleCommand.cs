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
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class CreateRoleCommandHanddler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IIdentityService _service;

        public CreateRoleCommandHanddler(IIdentityService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _service.CreateRole(request.Name);

            return Unit.Value;
        }
    }
}
