using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PersonLists.Queries.GetPersonsQuery
{
    public class GetUserNamesQuery : IRequest<List<string>>
    {

    }

    public class GetUserNamesQueryHandler : IRequestHandler<GetUserNamesQuery, List<string>>
    {
        private readonly IIdentityService _service;

        public GetUserNamesQueryHandler(IIdentityService service)
        {
            _service = service;
        }        

        public async Task<List<string>> Handle(GetUserNamesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<string> userName = _service.GetAllUserNames();
                //return Task.FromResult(userName);
                return userName;
            }
            catch
            {
                throw;
            }
        }
    }
}
