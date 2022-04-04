using MediatR;
using StockManagment.Application.Common.Exceptions;
using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace StockManagment.Application.Consignees.Commands.DeleteConsignee
{

    public class DeleteConsigneeCommand : IRequest
    {
        public string Code { get; set; }
    }

    public class DeleteConsigneeCommanHandler : IRequestHandler<DeleteConsigneeCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteConsigneeCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteConsigneeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Consignees
               .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Consignee), request.Code);
            }

            _context.Consignees.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
