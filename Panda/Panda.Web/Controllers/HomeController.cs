namespace Panda.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Services.Interfaces;
    using Panda.Web.Models.ViewModels;

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IPackageService _packageService;

        public HomeController(IPackageService packageService)
        {
            this._packageService = packageService;
        }

        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;

                var packages = new PackageViewModel(_packageService.GetPendingPackagesByUser(username),
                                                    _packageService.GetShippedPackagesByUser(username),
                                                    _packageService.GetDeliveredAndAcquiredPackagesByUser(username));

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
