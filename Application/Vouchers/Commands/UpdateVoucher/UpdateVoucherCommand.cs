using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using StockManagment.Application.Common.Exceptions;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Generic;

namespace StockManagment.Application.Vouchers.Commands.UpdateVoucher
{

    public class UpdateVoucherCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public double SubTotal { get; set; }
        public double GrandTotal { get; set; }
        public bool Void { get; set; }
        public string ConsigneeCode { get; set; }
    }

    public class UpdateVoucherCommanHandler : IRequestHandler<UpdateVoucherCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVoucherCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVoucherCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vouchers
                  .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Voucher), request.Code);
            }

            entity.Remark = request.Remark;
            entity.Type = request.Type;
            entity.TimeStamp = request.TimeStamp;
            entity.SubTotal = request.SubTotal;
            entity.GrandTotal = request.GrandTotal;
            entity.Void = request.Void;
            entity.ConsigneeCode = request.ConsigneeCode;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
