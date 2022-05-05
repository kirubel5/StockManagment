using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Domain.Entities
{
    public class RoleModel
    {
        public string Name { get; set; }

        public bool ConsigneeCreate { get; set; } = false;
        public bool ConsigneeRead { get; set; } = false;
        public bool ConsigneeUpdate { get; set; } = false;
        public bool ConsigneeDelete { get; set; } = false;

        public bool ElementCreate { get; set; } = false;
        public bool ElementRead { get; set; } = false;
        public bool ElementUpdate { get; set; } = false;
        public bool ElementDelete { get; set; } = false;

        public bool PersonCreate { get; set; } = false;
        public bool PersonRead { get; set; } = false;
        public bool PersonUpdate { get; set; } = false;
        public bool PersonDelete { get; set; } = false;

        public bool VoucherCreate { get; set; } = false;
        public bool VoucherRead { get; set; } = false;
        public bool VoucherUpdate { get; set; } = false;
        public bool VoucherDelete { get; set; } = false;
    }
}
