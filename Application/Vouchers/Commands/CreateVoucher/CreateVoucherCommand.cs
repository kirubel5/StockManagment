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
        public string Remark { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public double SubTotal { get; set; }
        public double GrandTotal { get; set; }
        public bool Void { get; set; }
        public string ConsigneeCode { get; set; }
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
            string randomCode = new Random().Next(0, 100000).ToString();

            var entity = new Voucher
            {
                Code = randomCode,
                Remark = request.Remark,
                Type = request.Type,
                TimeStamp = request.TimeStamp,
                SubTotal = request.SubTotal,
                GrandTotal = request.GrandTotal,
                Void = request.Void,
                ConsigneeCode = request.ConsigneeCode
            };

            foreach (var item in request.LineItems)
            {
                item.VoucherCode = randomCode;
                item.Code = new Random().Next(0, 100000).ToString();

                _context.LineItems.Add(item);
            }

            _context.Vouchers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
