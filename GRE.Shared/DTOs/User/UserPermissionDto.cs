using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.DTOs.User
{
    public class UserPermissionDto
    {
        public int UserPermissionId { get; set; }
        public int UserId { get; set; }
        public bool CanViewOrderHistory { get; set; }
        public bool CanOrderSalesProducts { get; set; }
        public bool CanOrderPromoProducts { get; set; }
    }
}
