using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Domain.Models.Users
{
    public class UserPermissionModel
    {
        public int UserPermissionId { get; set; }
        public int UserId { get; set; }
        public bool CanViewOrderHistory { get; set; }
        public bool CanOrderSalesProducts { get; set; }
        public bool CanOrderPromoProducts { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime DateAdded { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }
}
