using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using StockManagment.Application.Common.Exceptions;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace StockManagment.Application.LineItems.Commands.UpdateLineItem
{

    public class UpdateLineItemCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public float UnitAmount { get; set; }
        public float Quantity { get; set; }
        public float TaxableAmount { get; set; }
        public string TaxType { get; set; }
        public float TaxAmount { get; set; }
        public string ElementCode { get; set; }
        public string VoucherCode { get; set; }
    }

    public class UpdateLineItemCommanHandler : IRequestHandler<UpdateLineItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLineItemCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLineItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.LineItems
                  .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(LineItem), request.Code);
            }

            entity.Remark = request.Remark;
            entity.UnitAmount = request.UnitAmount;
            entity.Quantity = request.Quantity;
            entity.TaxableAmount = request.TaxableAmount;
            entity.TaxType = request.TaxType;
            entity.TaxAmount = request.TaxAmount;
            entity.VoucherCode = request.VoucherCode;
            entity.ElementCode = request.ElementCode;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
