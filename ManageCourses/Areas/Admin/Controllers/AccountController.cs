using ManageCourses.Areas.Admin.Models;
using ManageCourses.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ManageCourses.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        public IAccountRepository Repo { get; }
        public AccountController(IAccountRepository repo)
        {
            Repo = repo;
        }

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
                if (Repo.Login(login.email,login.password))
                    return RedirectToAction("Index", "Dashboard");
            return View(login);
        }
        #endregion

    }
}
