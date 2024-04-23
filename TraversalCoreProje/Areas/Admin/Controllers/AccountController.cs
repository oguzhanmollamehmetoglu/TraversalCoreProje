using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(AccountViewModel model)
        {
            var valuesSender = _accountService.TGetByID(model.SenderID);
            var valuesReceiver = _accountService.TGetByID(model.ReceiverID);
            valuesSender.Balance -= model.Amount;
            valuesReceiver.Balance += model.Amount;
            List<Account> modifiedAccount = new List<Account>()
            {
                valuesSender,
                valuesReceiver
            };
            _accountService.TMultiUpdate(modifiedAccount);
            return View();
        }
    }
}