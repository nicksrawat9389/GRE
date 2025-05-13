using GRE.Shared.CommonMethods;
using GRE.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace GRE.WebApi.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        public TokenModel GetToken(HttpContext httpContext)
        {
            return CommonMethods.GetTokenDataModel(httpContext);
        }
    }
}
