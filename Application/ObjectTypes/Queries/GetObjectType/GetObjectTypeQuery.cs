using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.ObjectTypes.Queries.GetObjectType
{
    public class GetObjectTypeQuery : IRequest<ObjectTypeDto>
    {
        public string Code { get; set; }
    }

    public class GetObjectTypeQueryHandler : IRequestHandler<GetObjectTypeQuery, ObjectTypeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetObjectTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ObjectTypeDto> Handle(GetObjectTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var a = _context.ObjectTypes
                    .Where(x => x.Code == request.Code)
                    .ProjectTo<ObjectTypeDto>(_mapper.ConfigurationProvider).FirstOrDefault();

                return Task.FromResult(a);                
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
