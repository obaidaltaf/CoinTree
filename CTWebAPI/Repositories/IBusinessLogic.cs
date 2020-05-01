using CTWebAPI.Models;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public interface IBusinessLogic
    {
        CryptoRatesViewModel GetCryptoRate(DataTableParams dataTableParams);
        Task<int> RefreshCryptoRate();
    }
}