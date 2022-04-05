﻿using StockManagment.Domain.Common;

namespace StockManagment.Domain.Entities
{
    public class LineItem : EntityCommon
    {
        public string Type { get; set; }
        public string Element { get; set; }
        public double UnitAmount { get; set; }
        public double Quantity { get; set; }
        public double TaxableAmount { get; set; }
        public string TaxType { get; set; }
        public double TaxAmount { get; set; }
        public double Cost { get; set; }
    }
}