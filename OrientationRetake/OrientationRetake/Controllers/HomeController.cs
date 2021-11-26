using Microsoft.AspNetCore.Mvc;

namespace OrientationRetake.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult MainPage()
        {
            return View();
        }
    }
}