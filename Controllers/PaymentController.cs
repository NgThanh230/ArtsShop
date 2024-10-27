using Microsoft.AspNetCore.Mvc;

namespace ArtsShop.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
