using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.Persons.Queries.GetPerson
{
    public class GetPersonQuery : IRequest<PersonDto>
    {
        public string Code { get; set; }
    }

    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<PersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var a = _context.Persons
                    .Where(x => x.Code == request.Code)
                    .ProjectTo<PersonDto>(_mapper.ConfigurationProvider).FirstOrDefault();

                return Task.FromResult(a);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
