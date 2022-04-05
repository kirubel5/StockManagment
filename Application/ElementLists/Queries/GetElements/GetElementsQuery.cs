using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ElementLists.Queries.GetElements
{
    public class GetElementsQuery : IRequest<ElementList>
    {

    }

    public class GetElementsQueryHandler : IRequestHandler<GetElementsQuery, ElementList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetElementsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ElementList> Handle(GetElementsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new ElementList
                {
                    Lists = await _context.Elements
                    .ProjectTo<ElementListDto>(_mapper.ConfigurationProvider)
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
