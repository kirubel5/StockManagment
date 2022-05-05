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

namespace Application.RoleList.Queries.GetRolesQuery
{
    public class GetRolesQuery : IRequest<RoleList>
    {

    }

    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, RoleList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRolesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoleList> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new RoleList
                {
                    Lists = await _context.RoleModels
                    .ProjectTo<RoleListDto>(_mapper.ConfigurationProvider)
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
