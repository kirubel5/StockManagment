using MediatR;
using StockManagment.Application.Common.Exceptions;
using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace StockManagment.Application.Vouchers.Commands.DeleteVoucher
{

    public class DeleteVoucherCommand : IRequest
    {
        public string Code { get; set; }
    }

    public class DeleteVoucherCommanHandler : IRequestHandler<DeleteVoucherCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVoucherCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVoucherCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vouchers
               .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Voucher), request.Code);
            }

            _context.Vouchers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
