using StockManagment.Domain.Common;
using System;

namespace StockManagment.Domain.Entities
{
    public class Person : EntityActivity
    {
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
