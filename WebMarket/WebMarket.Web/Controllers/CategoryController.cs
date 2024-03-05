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
    }
}
