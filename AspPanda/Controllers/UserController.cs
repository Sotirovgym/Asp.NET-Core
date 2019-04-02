﻿using AspCorePanda.BindingModels;
//using AspCorePanda.Data.Managers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspCorePanda.Controllers
{
    public class UserController : Controller
    {
        //private UserManager userManager;

        //public UserController()
        //{
        //    this.userManager = new UserManager();
        //}

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
                //this.userManager.CreateUser(user);
                return RedirectToAction("Home", "Index");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}