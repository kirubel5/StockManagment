using StockManagment.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Application.Common.Interfaces;

namespace StockManagment.Application.LineItems.Commands.CreateLineItem
{

    public class CreateLineItemCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public double UnitAmount { get; set; }
        public double Quantity { get; set; }
        public double TaxableAmount { get; set; }
        public string TaxType { get; set; }
        public double TaxAmount { get; set; }
        public string ElementCode { get; set; }
        public string VoucherCode { get; set; }
    }

    public class CreateLineItemCommanHandler : IRequestHandler<CreateLineItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateLineItemCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateLineItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new LineItem
            {
                Code = request.Code,
                Remark = request.Remark,
                UnitAmount = request.UnitAmount,
                Quantity = request.Quantity,
                TaxableAmount = request.TaxableAmount,
                TaxType = request.TaxType,
                TaxAmount = request.TaxAmount,
                ElementCode = request.ElementCode,
                VoucherCode = request.VoucherCode
            };

            _context.LineItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
