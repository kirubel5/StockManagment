using Application.Common.Interfaces;
using MediatR;
using StockManagment.Application.Common.Exceptions;
using StockManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.ObjectTypes.Commands.UpdateObjectType
{
    public class UpdateObjectTypeCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }

    public class UpdateObjectTypeCommanHandler : IRequestHandler<UpdateObjectTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateObjectTypeCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateObjectTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ObjectTypes
                  .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ObjectType), request.Code);
            }

            entity.Description = request.Description;
            entity.Active = request.Active;
            entity.Remark = request.Remark;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
