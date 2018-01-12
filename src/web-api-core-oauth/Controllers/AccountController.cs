using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            // TODO : Map avec le token
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();

            //Just redirect to our index after logging in. 
            return Redirect("/");

        }
    }
}
