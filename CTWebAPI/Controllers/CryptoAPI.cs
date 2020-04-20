using CTWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoAPI : Controller
    {
        private IBusinessLogic _businessLogic { get; }
        public CryptoAPI(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        [HttpGet]
        [Produces(typeof(List<CryptoRates>))]
        public async Task<List<CryptoRates>> Get()
        {
            return await _businessLogic.GetCryptoRate();
        }
    }
}
