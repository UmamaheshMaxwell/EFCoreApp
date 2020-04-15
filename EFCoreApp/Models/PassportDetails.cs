using System;
using System.Collections.Generic;

namespace EFCoreApp.Models
{
    public partial class PassportDetails
    {
        public int PkPassportId { get; set; }
        public string PassportNumber { get; set; }
        public int? FkPersonId { get; set; }

        public virtual Person FkPerson { get; set; }
    }
}
