using StockManagment.Application.Common.Mappings;
using StockManagment.Domain.Entities;
using System;

namespace Application.PersonLists.Queries.GetPersonsQuery
{
    public class PersonListDto : IMapFrom<Person>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
