namespace Panda.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Services.Interfaces;
    using Panda.Web.Models.ViewModels;
    using System;

    [Authorize(Roles = "User, Admin")]
    public class ReceiptController : Controller
    {
        private IReceiptService _receiptService;
        private IPackageService _packageService;

        public ReceiptController(IReceiptService receiptService, IPackageService packageService)
        {
            _receiptService = receiptService;
            _packageService = packageService;
        }

        public IActionResult Details(Guid id)
        {
            var receipt = _receiptService.GetReceiptById(id);
            var package = _packageService.GetPackageById(receipt.PackageId);

            var receiptDetails = new ReceiptDetailsViewModel()
            {
                Id = receipt.Id,
                IssuedOn = receipt.IssuedOn,
                DeliveryAddress = package.ShippingAddreess,
                PackageWeight = package.Weight,
                PackageDescription = package.Description,
                Recipient = User.Identity.Name,
                TotalPrice = receipt.Fee
            };

            return this.View(receiptDetails);
        }

        
        public IActionResult Index()
        {
            var username = User.Identity.Name;

            var userReceipts = _receiptService.GetUserReceipts(username);

            return View(userReceipts);
        }
    }
}