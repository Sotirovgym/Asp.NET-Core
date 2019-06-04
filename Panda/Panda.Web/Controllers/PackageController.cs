namespace Panda.Web.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Services.Interfaces;
    using Panda.Web.Models.ViewModels;

    public class PackageController : Controller
    {
        private IPackageService _packageService;
        private IUserService _userService;

        public PackageController(IPackageService packageService, IUserService userService)
        {
            _packageService = packageService;
            _userService = userService;
        }

        [Authorize(Roles = "User, Admin")]
        public IActionResult Details(Guid id)
        {
            var package = _packageService.GetPackageById(id);
            var user = _userService.GetUserById(package.RecipientId);

            var packageDetailsViewModel = new PackageDetailsViewModel
            {
                Id = package.Id,
                Description = package.Description,
                Weight = package.Weight,
                ShippingAddreess = package.ShippingAddreess,
                Status = package.Status,
                EstimatedDeliveryDate = package.EstimatedDeliveryDate,
                RecipientName = user.UserName
            };

            return View(packageDetailsViewModel);
        }
    }
}