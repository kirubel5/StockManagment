using StockManagment.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Application.Common.Interfaces;

namespace StockManagment.Application.Consignees.Commands.CreateConsignee
{

    public class CreateConsigneeCommand : IRequest
    {
        public string Code { get; set; } 
        public string Remark { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string BusinessType { get; set; }
    }

    public class CreateConsigneeCommanHandler : IRequestHandler<CreateConsigneeCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateConsigneeCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateConsigneeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Consignee
            {
                Code = request.Code,
                Name = request.Name,
                TradeName = request.TradeName,
                BusinessType = request.BusinessType,
                Active = request.Active,
                Remark = request.Remark,
                Type = request.Type
            };

            _context.Consignees.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
