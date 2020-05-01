using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTWebAPI.Models
{
    public class CryptoRatesViewModel
    {
        public DataTableParams DataTableParams { get; set; }
        public List<CryptoRates> CryptoRatesList { get; set; }

        public CryptoRatesViewModel()
        {
            DataTableParams = new DataTableParams();
            CryptoRatesList = new List<CryptoRates>();
        }
    }
}
