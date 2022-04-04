using StockManagment.Application.Common.Mappings;
using System.Collections.Generic;

namespace Application.ConsigneeLists.Queries.GetConsignees
{
    public class ConsigneeList
    {
        public IList<ConsigneeDto> Lists { get; set; } = new List<ConsigneeDto>();
    }

}
