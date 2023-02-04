using ManageCourses.Areas.Admin.Models;
using ManageCourses.Models;
using ManageCourses.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ManageCourses.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        public CategoryController(ICategoryRepository repo)
        {
            Repo = repo;
        }

        public ICategoryRepository Repo { get; }
        #region Show all cat
        public IActionResult Index()
        {
            List<category> data = Repo.GetAll();
            return View(data);
        }
        #endregion
        #region Insert catgs
        public IActionResult AddNewCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(CategoryVM m)
        {
            if (ModelState.IsValid)
            {
                Repo.add(m);
                return RedirectToAction("index");
            }
            return View(m);
        }

        public IActionResult checkName(string name)
        {
            CategoryVM c = Repo.getByName(name);
            if (c == null)
                return Json(true);
            return Json(false);
        }
        #endregion
        #region Update
        public IActionResult UpdateCategory(int id)
        {
            return View(Repo.getById(id));
        }
        [HttpPost]
        public IActionResult UpdateCategory(int id, CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                Repo.update(id, vm);
                return RedirectToAction("index");
            }
            return View(vm);
        }
        #endregion


        #region Delete
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                int del = Repo.delete(id);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
