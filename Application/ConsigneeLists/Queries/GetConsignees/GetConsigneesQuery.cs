using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ConsigneeLists.Queries.GetConsignees
{  
    public class GetConsigneesQuery : IRequest<ConsigneeList>
    {

    }

    public class GetConsigneesQueryHandler : IRequestHandler<GetConsigneesQuery, ConsigneeList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetConsigneesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ConsigneeList> Handle(GetConsigneesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new ConsigneeList
                {
                    Lists = await _context.Consignees
                    .ProjectTo<ConsigneeListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
