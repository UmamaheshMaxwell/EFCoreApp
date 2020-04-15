using System;
using System.Collections.Generic;

namespace EFCoreApp.Models
{
    public partial class Person
    {
        public int PkPersonId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

        public virtual PassportDetails PassportDetails { get; set; }
    }
}
