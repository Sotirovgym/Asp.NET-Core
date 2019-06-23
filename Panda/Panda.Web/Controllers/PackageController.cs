namespace Panda.Web.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Models.Entities;
    using Panda.Services.Interfaces;
    using Panda.Web.Models.ViewModels;

    public class PackageController : Controller
    {
        private IPackageService _packageService;
        private IUserService _userService;
        private IReceiptService _receiptService;

        public PackageController(IPackageService packageService, 
                                 IUserService userService,
                                 IReceiptService receiptService)
        {
            _packageService = packageService;
            _userService = userService;
            _receiptService = receiptService;
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

        [Authorize(Roles = "User, Admin")]
        public IActionResult AcquirePackage(Guid Id)
        {
            var package = _packageService.GetPackageById(Id);

            var receipt = new Receipt
            {
                Fee = package.Weight * 2.67m,
                IssuedOn = DateTime.Now,
                PackageId = package.Id,
                RecipientId = package.RecipientId
            };

            _receiptService.AddReceipt(receipt);
            _packageService.SetStatusToAcquired(package.Id);

            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ShippedPackages()
        {
            var packages = _packageService.GetShippedPackages();

            return this.View(packages);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult PendingPackages()
        {
            var packages = _packageService.GetPendingPackages();

            return this.View(packages);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeliveredPackages()
        {
            var packages = _packageService.GetDeliveredAndAcquiredPackages();

            return this.View(packages);
        }
    }
}