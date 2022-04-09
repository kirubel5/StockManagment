using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using StockManagment.Application.Common.Exceptions;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace StockManagment.Application.Consignees.Commands.UpdateConsignee
{

    public class UpdateConsigneeCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string BusinessType { get; set; }
        public string Type { get; set; }
    }

    public class UpdateConsigneeCommanHandler : IRequestHandler<UpdateConsigneeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateConsigneeCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateConsigneeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Consignees
                  .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Consignee), request.Code);
            }

            entity.Name = request.Name;
            entity.TradeName = request.TradeName;
            entity.BusinessType = request.BusinessType;
            entity.Active = request.Active;
            entity.Remark = request.Remark;
            entity.Type = request.Type;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
