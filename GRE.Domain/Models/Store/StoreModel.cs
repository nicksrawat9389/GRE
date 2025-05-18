using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Domain.Models.Store
{
    public class StoreModel : AddressModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string AccountStatus { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }

}
