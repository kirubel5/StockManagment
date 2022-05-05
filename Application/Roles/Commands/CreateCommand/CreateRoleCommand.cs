using Application.Common.Interfaces;
using MediatR;
using StockManagment.Domain.Entities;
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
        private readonly IApplicationDbContext _context;

        public CreateRoleCommandHanddler(IIdentityService service, IApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = new RoleModel
            {
                Name = request.Name
            };

            await _service.CreateRole(request.Name);
            _context.RoleModels.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
