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
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class CreateRoleCommandHanddler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IIdentityService _service;
        private readonly IApplicationDbContext _context;

        public CreateRoleCommandHanddler(IIdentityService service, IApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {         
            await _service.CreateRole(request.Name);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
