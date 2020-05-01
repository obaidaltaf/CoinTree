using CTWebAPI.Controllers;
using CTWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpPost]
        public IActionResult PullCryptoList()
        {
            DataTableParams dataTableParams = new DataTableParams();
            dataTableParams.start = Convert.ToInt32(Request.Form["start"]);
            dataTableParams.length = Convert.ToInt32(Request.Form["length"]);
            dataTableParams.draw = Convert.ToInt32(Request.Form["draw"]);
            dataTableParams.searchValue = Request.Form["search[value]"];
            CryptoRatesViewModel cryptoRatesViewModel = _businessLogic.GetCryptoRate(dataTableParams);
            return Json(new { data = cryptoRatesViewModel.CryptoRatesList, draw = dataTableParams.draw, recordsTotal = cryptoRatesViewModel.DataTableParams.totalRows, recordsFiltered = cryptoRatesViewModel.DataTableParams.totalRowsAfterfiltering });
        }
    }
}