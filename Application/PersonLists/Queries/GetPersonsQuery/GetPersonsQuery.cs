using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PersonLists.Queries.GetPersonsQuery
{
    public class GetPersonsQuery : IRequest<PersonList>
    {

    }

    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, PersonList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PersonList> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new PersonList
                {
                    Lists = await _context.Persons
                    .ProjectTo<PersonListDto>(_mapper.ConfigurationProvider)
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
