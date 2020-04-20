using CTWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public interface IDataAccess
    {
        Task<List<CryptoRates>> saveCryptoRate(List<CryptoRates> cryptoRates);
    }
}