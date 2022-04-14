using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConsigneeLists.Queries.GetConsignees
{
    public class ConsigneeListDto : IMapFrom<Consignee>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string BusinessType { get; set; }
    }
}
