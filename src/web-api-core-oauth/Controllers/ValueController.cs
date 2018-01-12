using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Authorize]
    [Route("api/values")]
    public class ValueController : Controller
    {
        public string Index()
        {
            return "yay";
        }
    }
}
