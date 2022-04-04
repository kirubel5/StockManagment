using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.LineItems.Queries.GetLineItem
{
    public class GetLineItemQuery : IRequest<LineItemDto>
    {
        public string Code { get; set; }
    }

    public class GetLineItemQueryHandler : IRequestHandler<GetLineItemQuery, LineItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLineItemQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<LineItemDto> Handle(GetLineItemQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var a = _context.LineItems
                    .Where(x => x.Code == request.Code)
                    .ProjectTo<LineItemDto>(_mapper.ConfigurationProvider).FirstOrDefault();

                return Task.FromResult(a);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
