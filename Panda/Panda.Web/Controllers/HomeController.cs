namespace Panda.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Models.Enums;
    using Panda.Services.Interfaces;
    using Panda.Web.Models.ViewModels;

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
