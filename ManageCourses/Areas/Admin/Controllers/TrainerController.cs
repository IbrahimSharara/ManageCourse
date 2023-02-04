using ManageCourses.Areas.Admin.Models;
using ManageCourses.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageCourses.Areas.Admin.Controllers
{
    [Area("admin")]
    public class TrainerController : Controller
    {
        public ITrainerRepository Repo { get; }

        public TrainerController(ITrainerRepository repo)
        {
            Repo = repo;
        }
        #region GET: TrainerController
        public ActionResult Index()
        {
            return View(Repo.GetAll());
        }
        #endregion

        #region TrainerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainerVM m)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repo.add(m);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(m);

        }
        #endregion
        #region TrainerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repo.getById(id));
        }

        // POST: TrainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,TrainerVM vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Repo.update(id, vm);
                    return RedirectToAction(nameof(Index));
                }
                return View(vm);
            }
            catch
            {
                return View(vm);
            }
        }
        #endregion
        #region TrainerController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TrainerController/Delete/5
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Repo.delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region check Unique
        public IActionResult checkName(string name)
        {
            TrainerVM t = Repo.getByName(name);
            if (t == null)
                return Json(true);
            return Json(false);
        }
        public IActionResult checkEmail(string email)
        {
            TrainerVM t = Repo.getByEmail(email);
            if (t == null)
                return Json(true);
            return Json(false);
        }
        #endregion
    }
}
