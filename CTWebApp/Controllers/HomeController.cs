using CTWebAPI.Controllers;
using CTWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IBusinessLogic _businessLogic { get; }

        public HomeController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> PullCryptoList()
        {
            List<CryptoRates> cryptoRatesList = await _businessLogic.GetCryptoRate();
            return PartialView("_CryptoListing", cryptoRatesList);
        }
    }
}
