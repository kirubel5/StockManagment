using Application.Common.Interfaces;
using MediatR;
using StockManagment.Application.Common.Exceptions;
using StockManagment.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.Elements.Commands.UpdateElement
{
    public class UpdateElementCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string UOM { get; set; }
    }

    public class UpdateElementCommandHandler : IRequestHandler<UpdateElementCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateElementCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateElementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Elements
                  .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Element), request.Code);
            }

            entity.Name = request.Name;
            entity.Active = request.Active;
            entity.Remark = request.Remark;
            entity.UOM = request.UOM;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}