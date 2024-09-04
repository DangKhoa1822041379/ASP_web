using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TheLoai : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return Ok("Id: " + id);
        }

        //public IActionResult Detail(int id,string ten)
        //{
        //    return Content("Id: " + id +" ; ten: "+ ten);
        //}


        public IActionResult Detail(int id,string ten)
        {
            //    return Content("Id: " + id +" ; ten: "+ ten);
            return Content(string.Format("id: {0}; ten: {1}",id, ten));
        }

        public IActionResult Show(List<string> categories)
        {
            string content = "Danh sách thể loại: ";
            foreach (var category in categories)
            {
                content = content + " " + category + ", ";
            }
            return Content(content);
        }
    }
}
