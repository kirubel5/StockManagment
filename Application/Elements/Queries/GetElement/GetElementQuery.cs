using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using StockManagment.Application.Common.Exceptions;
using Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace StockManagment.Application.Elements.Queries.GetElement
{
    public class GetElementQuery : IRequest<ElementDto>
    {
        public string Code { get; set; }
    }

    public class GetElementQueryHandler : IRequestHandler<GetElementQuery, ElementDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetElementQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ElementDto> Handle(GetElementQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_context.Elements
                    .Where(x => x.Code == request.Code)
                    .ProjectTo<ElementDto>(_mapper.ConfigurationProvider).FirstOrDefault());
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
