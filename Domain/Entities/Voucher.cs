using StockManagment.Domain.Common;
using System;
using System.Collections.Generic;

namespace StockManagment.Domain.Entities
{
    public class Voucher : EntityCommon
    {
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public float SubTotal { get; set; }
        public float GrandTotal { get; set; }
        public bool Void { get; set; }
        public string ConsigneeCode { get; set; }
    }
}
