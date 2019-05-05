namespace Panda.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Models.Entities;
    using Panda.Services.Interfaces;

    public class PackageController : Controller
    {
        private IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            this._packageService = packageService;
        }

        public IActionResult Details(Guid id)
        {
            var package = _packageService.GetPackageById(id);

            return View(package);
        }
    }
}