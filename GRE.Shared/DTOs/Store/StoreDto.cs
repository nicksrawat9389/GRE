using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.DTOs.Store
{
    public class StoreDto : AddressesDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string AccountStatus { get; set; }
        
    }
}
