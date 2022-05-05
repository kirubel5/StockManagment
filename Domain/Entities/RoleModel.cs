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

        public bool ConsigneeCreate { get; set; }
        public bool ConsigneeRead { get; set; }
        public bool ConsigneeUpdate { get; set; }
        public bool ConsigneeDelete { get; set; }

        public bool ElementCreate { get; set; }
        public bool ElementRead { get; set; }
        public bool ElementUpdate { get; set; }
        public bool ElementDelete { get; set; }

        public bool PersonCreate { get; set; }
        public bool PersonRead { get; set; }
        public bool PersonUpdate { get; set; }
        public bool PersonDelete { get; set; }

        public bool VoucherCreate { get; set; }
        public bool VoucherRead { get; set; }
        public bool VoucherUpdate { get; set; }
        public bool VoucherDelete { get; set; }
    }
}
