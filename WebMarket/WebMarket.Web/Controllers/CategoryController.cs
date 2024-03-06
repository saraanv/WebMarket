using Microsoft.AspNetCore.Mvc;
using WebMarket.Web.Data;
using WebMarket.Web.Models;

namespace WebMarket.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.Categories;
            return View(CategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "فیلد نام نمیتواند با فیلد ترتیب نمایش برابر باشد");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "دسته با موفقیت افزوده شد";
                return RedirectToAction("Index");
            }
            return View();
        }


        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
            return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
               
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "فیلد نام نمیتواند با فیلد ترتیب نمایش برابر باشد");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "دسته با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
                var obj = _db.Categories.Find(id);
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "دسته با موفقیت حذف شد";
            return RedirectToAction("Index");
           
        }
    }
}
