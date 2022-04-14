using MediatR;
using Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using StockManagment.Domain.Entities;

namespace StockManagment.Application.Elements.Commands.CreateElement
{
    public class CreateElementCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string UOM { get; set; }
    }

    public class CreateElementCommandHandler : IRequestHandler<CreateElementCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateElementCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateElementCommand request, CancellationToken cancellationToken)
        {
            var entity = new Element
            {
                Code = request.Code,
                UOM = request.UOM,
                Name = request.Name,
                Active = request.Active,
                Remark = request.Remark
            };

            _context.Elements.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
