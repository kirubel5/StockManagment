using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.Consignees.Queries.GetConsignee
{
    public class GetConsigneeQuery : IRequest<ConsigneeDto>
    {
        public string Code { get; set; }
    }

    public class GetConsigneeQueryHandler : IRequestHandler<GetConsigneeQuery, ConsigneeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetConsigneeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ConsigneeDto> Handle(GetConsigneeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var a = _context.Consignees
                    .Where(x => x.Code == request.Code)
                    .ProjectTo<ConsigneeDto>(_mapper.ConfigurationProvider).FirstOrDefault();
                 
                return Task.FromResult(a);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
