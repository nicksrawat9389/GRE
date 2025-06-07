using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Domain.Models.ContactSupport
{
    public class ContactSupportModel
    {
        public int SupportId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }
}
