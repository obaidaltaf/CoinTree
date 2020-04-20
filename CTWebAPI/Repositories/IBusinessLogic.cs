using CTWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public interface IBusinessLogic
    {
        Task<List<CryptoRates>> GetCryptoRate();
    }
}