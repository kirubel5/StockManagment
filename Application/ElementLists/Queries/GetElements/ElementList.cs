using System.Collections.Generic;

namespace Application.ElementLists.Queries.GetElements
{
    public class ElementList
    {
        public IList<ElementListDto> Lists { get; set; } = new List<ElementListDto>();
    }
}
