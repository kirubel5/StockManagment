using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RoleLists.Queries.GetRoles
{
    public class GetRolesQuery : IRequest<RoleList>
    {

    }

    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, RoleList>
    {
        private readonly IIdentityService _service;
        private readonly IMapper _mapper;

        public GetRolesQueryHandler(IIdentityService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<RoleList> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var a = _service.GetRoles();
                RoleList list = new RoleList();

                foreach (var item in a)
                {
                    list.Lists.Add(item);
                }

                return Task.FromResult(list);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
