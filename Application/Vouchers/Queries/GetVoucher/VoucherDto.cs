using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application.Vouchers.Queries.GetVoucher
{
    public class VoucherDto : IMapFrom<Voucher>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public float SubTotal { get; set; }
        public float GrandTotal { get; set; }
        public bool Void { get; set; }
        public string ConsigneeCode { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}