using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IIdentityService _service;
        private readonly IApplicationDbContext _context;

        public DeleteRoleCommandHandler(IIdentityService service, IApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteRole(request.Name);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
