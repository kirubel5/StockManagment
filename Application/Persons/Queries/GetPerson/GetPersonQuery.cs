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
        public string UserName { get; set; }
    }

    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _service;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService service)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var id = await _service?.GetUserIdAsync(request.UserName);

                if (id == null)
                    return new PersonDto();

                var a = _context.Persons
                    .Where(x => x.Code == id)?
                    .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)?.FirstOrDefault();

                if (a == null)
                {
                    return new PersonDto();
                }

                return a;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
