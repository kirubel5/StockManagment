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
        public string Description { get; set; }
        public string UOM { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
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
                Description = request.Description,
                Active = request.Active,
                Group = request.Group,
                Remark = request.Remark,
                Type = request.Type
            };

            _context.Elements.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
