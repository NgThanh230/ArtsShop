using Microsoft.AspNetCore.Mvc;

namespace ArtsShop.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
