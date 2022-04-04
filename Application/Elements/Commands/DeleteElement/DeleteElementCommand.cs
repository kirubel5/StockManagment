using Application.Common.Interfaces;
using MediatR;
using StockManagment.Application.Common.Exceptions;
using StockManagment.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.Elements.Commands.DeleteElement
{
    public class DeleteElementCommand : IRequest
    {
        public string Code { get; set; }
    }

    public class DeleteElementCommandHandler : IRequestHandler<DeleteElementCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteElementCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteElementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Elements
              .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Element), request.Code);
            }

            _context.Elements.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
