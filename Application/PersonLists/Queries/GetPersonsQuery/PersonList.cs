using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonLists.Queries.GetPersonsQuery
{
    public class PersonList
    {
        public IList<PersonListDto> Lists { get; set; } = new List<PersonListDto>();
    }
}
