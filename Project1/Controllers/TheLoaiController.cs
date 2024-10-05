using Project1.Data;
using Project1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;

namespace Project1.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.ToList();
            ViewBag.theloai = theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                //Thêm thông tin vào bảng thể loại
                _db.TheLoai.Add(theLoai);
                //Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult Edit(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                //Thêm thông tin vào bảng thể loại
                _db.TheLoai.Update(theLoai);
                //Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }

        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if(theloai == null)
            {
                return NotFound();
            }
            _db.TheLoai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }

        [HttpGet]
        public IActionResult Search(String searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                //Sử dụng LINQ để tìm kiếm
                var theloai = _db.TheLoai.
                    Where(tl => tl.Name.Contains(searchString)).ToList();

                ViewBag.Search = searchString;
                ViewBag.TheLoai = theloai;
            }
            else
            {
                var theloai = _db.TheLoai.ToList();
                ViewBag.TheLoai = theloai;
            }
            return View("Index"); //Sử dụng lại View Index
        }
    }
}
