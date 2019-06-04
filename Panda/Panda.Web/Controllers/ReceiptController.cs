namespace Panda.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Panda.Services.Interfaces;

    public class ReceiptController : Controller
    {
        private IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [Authorize(Roles = "User, Admin")]
        public IActionResult Index()
        {
            var username = User.Identity.Name;

            var userReceipts = _receiptService.GetUserReceipts(username);

            return View(userReceipts);
        }
    }
}