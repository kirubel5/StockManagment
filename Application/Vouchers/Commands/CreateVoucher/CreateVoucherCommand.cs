using StockManagment.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace StockManagment.Application.Vouchers.Commands.CreateVoucher
{

    public class CreateVoucherCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public double SubTotal { get; set; }
        public double GrandTotal { get; set; }
        public bool Void { get; set; }
        public string Unit { get; set; }
        public string LastOperation { get; set; }
        public List<LineItem> LineItems { get; set; }
    }

    public class CreateVoucherCommanHandler : IRequestHandler<CreateVoucherCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateVoucherCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
        {
            var entity = new Voucher
            {
                Code = request.Code,
                Remark = request.Remark,
                Type = request.Type,
                TimeStamp = request.TimeStamp,
                SubTotal = request.SubTotal,
                GrandTotal = request.GrandTotal,
                Void = request.Void,
                Unit = request.Unit,
                LastOperation = request.LastOperation
            };

            foreach (var item in request.LineItems)
            {
                //item.VoucherCode = request.Code;
                _context.LineItems.Add(item);
            }

            _context.Vouchers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
