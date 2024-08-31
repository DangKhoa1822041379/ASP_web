using Microsoft.AspNetCore.Mvc;

namespace baitap3.Controllers
{
    public class NhomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
