using Application.Common.Interfaces;
using MediatR;
using StockManagment.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Commands.UpdateCommand
{
    public class UpdateRoleCommand : IRequest
    {
        public string Name { get; set; }

        public bool ConsigneeCreate { get; set; } = false;
        public bool ConsigneeRead { get; set; } = false;
        public bool ConsigneeUpdate { get; set; } = false;
        public bool ConsigneeDelete { get; set; } = false;

        public bool ElementCreate { get; set; } = false;
        public bool ElementRead { get; set; } = false;
        public bool ElementUpdate { get; set; } = false;
        public bool ElementDelete { get; set; } = false;

        public bool PersonCreate { get; set; } = false;
        public bool PersonRead { get; set; } = false;
        public bool PersonUpdate { get; set; } = false;
        public bool PersonDelete { get; set; } = false;

        public bool VoucherCreate { get; set; } = false;
        public bool VoucherRead { get; set; } = false;
        public bool VoucherUpdate { get; set; } = false;
        public bool VoucherDelete { get; set; } = false;
    }

    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRoleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RoleModels
                 .FindAsync(new object[] { request.Name }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Roles), request.Name);
            }

            entity.ConsigneeCreate = request.ConsigneeCreate;
            entity.ConsigneeRead = request.ConsigneeRead;
            entity.ConsigneeUpdate = request.ConsigneeUpdate;
            entity.ConsigneeDelete = request.ConsigneeDelete;

            entity.ElementCreate = request.ElementCreate;
            entity.ElementRead = request.ElementRead;
            entity.ElementUpdate = request.ElementUpdate;
            entity.ElementDelete = request.ElementDelete;

            entity.PersonCreate = request.PersonCreate;
            entity.PersonRead = request.PersonRead;
            entity.PersonUpdate = request.PersonUpdate;
            entity.PersonDelete = request.PersonDelete;

            entity.VoucherCreate = request.VoucherCreate;
            entity.VoucherRead = request.VoucherRead;
            entity.VoucherUpdate = request.VoucherUpdate;
            entity.VoucherDelete = request.VoucherDelete;

            return Unit.Value;
        }
    }
}
