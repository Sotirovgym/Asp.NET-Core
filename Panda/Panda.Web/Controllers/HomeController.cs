using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Panda.Data;
using Panda.Models.Entities;
using Panda.Models.Enums;
using Panda.Services.Interfaces;
using Panda.Web.Models.ViewModels;

namespace Panda.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var packages = new PackageViewModel(_userService.GetPackagesByStatus(Status.Pending),
                                                    _userService.GetPackagesByStatus(Status.Shipped),
                                                    _userService.GetPackagesByStatus(Status.Delivered));

                return this.View(packages);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
