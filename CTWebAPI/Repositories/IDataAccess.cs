using CTWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public interface IDataAccess
    {
        CryptoRatesViewModel getCryptoRate(DataTableParams dataTableParams);
        Task<int> saveCryptoRate(List<CryptoRates> cryptoRatesList);
    }
}