using Application.Common.Interfaces;
using MediatR;
using StockManagment.Application.Common.Exceptions;
using StockManagment.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.ObjectTypes.Commands.DeleteObjectType
{
    public class DeleteObjectTypeCommand : IRequest
    {
        public string Code { get; set; }
    }

    public class DeleteObjectTypeCommanHandler : IRequestHandler<DeleteObjectTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteObjectTypeCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteObjectTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ObjectTypes
               .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ObjectType), request.Code);
            }

            _context.ObjectTypes.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
