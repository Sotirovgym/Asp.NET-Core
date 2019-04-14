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

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return this.View(user);
            }

            return this.View();
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
                this.ModelState.AddModelError("Error", ex.Message);
                return this.View(user);
            }
        }
    }
}