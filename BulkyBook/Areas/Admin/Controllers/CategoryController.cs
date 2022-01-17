using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _uWork;
        public CategoryController(IUnitOfWork uWork)
        {
            _uWork = uWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _uWork.Category.GetAll();
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _uWork.Category.Add(obj);
                _uWork.Save();
                TempData["success"] = "Category created successfully!";
            }
                return RedirectToAction("Index");
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category category = _uWork.Category.GetFirstOrDefault(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _uWork.Category.Update(obj);
                _uWork.Save();
                TempData["success"] = "Category updated successfully!";
            }
            return RedirectToAction("Index");
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _uWork.Category.GetFirstOrDefault(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            _uWork.Category.Remove(obj);
            _uWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
