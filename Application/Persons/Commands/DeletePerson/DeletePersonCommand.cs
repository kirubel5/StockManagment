using MediatR;
using StockManagment.Application.Common.Exceptions;
using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace StockManagment.Application.Persons.Commands.DeletePerson
{

    public class DeletePersonCommand : IRequest
    {
        public string Code { get; set; }
    }

    public class DeletePersonCommanHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePersonCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons
               .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Code);
            }

            _context.Persons.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
