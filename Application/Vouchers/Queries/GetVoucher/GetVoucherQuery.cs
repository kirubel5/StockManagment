using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.Vouchers.Queries.GetVoucher
{
    public class GetVoucherQuery : IRequest<VoucherDto>
    {
        public string Code { get; set; }
    }

    public class GetVoucherQueryHandler : IRequestHandler<GetVoucherQuery, VoucherDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVoucherQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<VoucherDto> Handle(GetVoucherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var a = _context.Vouchers
                    .Where(x => x.Code == request.Code)
                    .ProjectTo<VoucherDto>(_mapper.ConfigurationProvider).FirstOrDefault();

                var b = _context.LineItems
               .Where(x => x.VoucherCode == a.Code);
                //.ProjectTo<VoucherDto>(_mapper.ConfigurationProvider);

                foreach (var item in b)
                {
                    a.LineItems.Add(item);
                }

                return Task.FromResult(a);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
