using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.Model
{
    public class TokenModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public int LocationID { get; set; }
        //public int StaffID { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        //publicint OffSet { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public HttpContext Request { get; set; }
    }
}
