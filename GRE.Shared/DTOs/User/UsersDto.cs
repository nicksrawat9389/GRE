using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.DTOs.User
{
    public class UsersDto : UserPermissionDto
    {
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool MfaEnabled { get; set; }
        public bool IsAdmin { get; set; }
        public string UserClassification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
