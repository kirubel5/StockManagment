using Application.Common.Interfaces;
using MediatR;
using StockManagment.Application.Common.Exceptions;
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
        private readonly IApplicationDbContext _context;

        public DeleteRoleCommandHanddler(IIdentityService service, IApplicationDbContext context )
        {
            _service = service;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {     
            var entity = await _context.RoleModels
              .FindAsync(new object[] { request.Name }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Roles), request.Name);
            }

            await _service.DeleteRole(request.Name);
            _context.RoleModels.Remove(entity);

            return Unit.Value;
        }
    }
}
