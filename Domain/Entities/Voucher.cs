﻿using StockManagment.Domain.Common;
using System;
using System.Collections.Generic;

namespace StockManagment.Domain.Entities
{
    public class Voucher : EntityCommon
    {
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public double SubTotal { get; set; }
        public double GrandTotal { get; set; }
        public bool Void { get; set; }
        public string Unit { get; set; }
        public string LastOperation { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
