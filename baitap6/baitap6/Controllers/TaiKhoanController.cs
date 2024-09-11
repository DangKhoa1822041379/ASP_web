using baitap6.Models;
using Microsoft.AspNetCore.Mvc;

namespace baitap6.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taiKhoan)
        {
            if (taiKhoan == null && taiKhoan.Password != null && taiKhoan.Password.Length > 0)
            {
                taiKhoan.Password = taiKhoan.Password + "_da_ma_hoa";
            }
            return View(taiKhoan);
        }
    }
}
