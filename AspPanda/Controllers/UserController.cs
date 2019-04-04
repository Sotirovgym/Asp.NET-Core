namespace AspCorePanda.Controllers
{
    using AspPanda.Data.Managers;
    using AspPanda.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class UserController : Controller
    {
        private UserManager userManager;

        public UserController()
        {
            this.userManager = new UserManager();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            try
            {
                this.userManager.CreateUser(user);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}