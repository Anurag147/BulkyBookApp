using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _uWork;
        public CoverTypeController(IUnitOfWork uWork)
        {
            _uWork = uWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCategoryList = _uWork.CoverType.GetAll();
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
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _uWork.CoverType.Add(obj);
                _uWork.Save();
                TempData["success"] = "Cover Type created successfully!";
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
            CoverType category = _uWork.CoverType.GetFirstOrDefault(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _uWork.CoverType.Update(obj);
                _uWork.Save();
                TempData["success"] = "Cover Type updated successfully!";
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
            CoverType category = _uWork.CoverType.GetFirstOrDefault(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CoverType obj)
        {
            _uWork.CoverType.Remove(obj);
            _uWork.Save();
            TempData["success"] = "Cover Type deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
