using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VoucherLists.Queries.GetVouchersQuery
{
    public class GetVouchersQuery : IRequest<VoucherList>
    {

    }

    public class GetVouchersQueryHandler : IRequestHandler<GetVouchersQuery, VoucherList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVouchersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VoucherList> Handle(GetVouchersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new VoucherList
                {
                    Lists = await _context.Vouchers
                    .ProjectTo<VoucherListDto>(_mapper.ConfigurationProvider)
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
