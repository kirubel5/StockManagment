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

namespace Application.ObjectTypeLists.Queries.GetObjectTypesQuery
{
    public class GetObjectTypesQuery : IRequest<ObjectTypeList>
    {

    }

    public class GetObjectTypesQueryHandler : IRequestHandler<GetObjectTypesQuery, ObjectTypeList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetObjectTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ObjectTypeList> Handle(GetObjectTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new ObjectTypeList
                {
                    Lists = await _context.ObjectTypes
                    .ProjectTo<ObjectTypeListDto>(_mapper.ConfigurationProvider)
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
