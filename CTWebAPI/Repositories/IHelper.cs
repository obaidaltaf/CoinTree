using CTWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public interface IHelper
    {
        Task<List<CryptoRates>> runAPI();
    }
}