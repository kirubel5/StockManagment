using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccessLevelModel
    {
        public string  Name { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}
