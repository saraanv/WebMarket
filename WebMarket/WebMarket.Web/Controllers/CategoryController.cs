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
    }
}
