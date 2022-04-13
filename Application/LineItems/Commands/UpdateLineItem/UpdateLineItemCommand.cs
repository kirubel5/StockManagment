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
        public string Reference { get; set; }
        public string Element { get; set; }
        public double UnitAmount { get; set; }
        public double Quantity { get; set; }
        public double TaxableAmount { get; set; }
        public string TaxType { get; set; }
        public double TaxAmount { get; set; }
        public double Cost { get; set; }
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
            entity.Reference = request.Reference;
            entity.Element = request.Element;
            entity.UnitAmount = request.UnitAmount;
            entity.Quantity = request.Quantity;
            entity.TaxableAmount = request.TaxableAmount;
            entity.TaxType = request.TaxType;
            entity.TaxAmount = request.TaxAmount;
            entity.Cost = request.Cost;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
