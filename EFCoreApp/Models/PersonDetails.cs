using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreApp.Models
{
    public class PersonDetails
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int PassportId { get; set; }
        public string PassportNumber { get; set; }
    }
}
