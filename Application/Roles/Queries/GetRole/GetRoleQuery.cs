using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Queries.GetRole
{
    public class GetRoleQuery : IRequest<RoleDto>
    {
        public string Name { get; set; }
    }

    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoleQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var a = _context.RoleModels
                    .Where(x => x.Name == request.Name)
                    .ProjectTo<RoleDto>(_mapper.ConfigurationProvider).FirstOrDefault();

                return Task.FromResult(a);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
