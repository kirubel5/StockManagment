using MediatR;
using StockManagment.Application.Common.Exceptions;
using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace StockManagment.Application.LineItems.Commands.DeleteLineItem
{

    public class DeleteLineItemCommand : IRequest
    {
        public string Code { get; set; }
    }

    public class DeleteLineItemCommanHandler : IRequestHandler<DeleteLineItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteLineItemCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLineItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.LineItems
               .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(LineItem), request.Code);
            }

            _context.LineItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
