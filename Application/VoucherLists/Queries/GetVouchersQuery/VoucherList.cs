using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VoucherLists.Queries.GetVouchersQuery
{
    public class VoucherList
    {
        public IList<VoucherListDto> Lists { get; set; } = new List<VoucherListDto>();
    }
}
