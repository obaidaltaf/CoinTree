using CTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public class DataAccess : IDataAccess
    {
        private readonly CoinTreeDBContext context;
        public DataAccess(CoinTreeDBContext _context)
        {
            context = _context;
        }

        public async Task<int> saveCryptoRate(List<CryptoRates> cryptoRatesList)
        {
            try
            {
                decimal? changePercentage = 0, spotRateDifference = 0;
                foreach (CryptoRates cryptoRates in cryptoRatesList)
                {
                    changePercentage = 0;
                    CryptoRates previousCryptoRates = context.CryptoRates.SingleOrDefault(c => c.sell == cryptoRates.sell && c.buy == cryptoRates.buy);
                    if (previousCryptoRates != null)
                    {
                        spotRateDifference = cryptoRates.spotRate - previousCryptoRates.spotRate;
                        if (spotRateDifference != 0)
                        {
                            if (previousCryptoRates.spotRate != 0)
                                changePercentage = (spotRateDifference / previousCryptoRates.spotRate) * 100;
                            previousCryptoRates.bid = cryptoRates.bid;
                            previousCryptoRates.rate = cryptoRates.rate;
                            previousCryptoRates.spotRate = cryptoRates.spotRate;
                            previousCryptoRates.market = cryptoRates.market;
                            previousCryptoRates.timestamp = cryptoRates.timestamp;
                            previousCryptoRates.rateType = cryptoRates.rateType;
                            previousCryptoRates.rateSteps = cryptoRates.rateSteps;
                            previousCryptoRates.changepercentage = Convert.ToDecimal(changePercentage);
                            context.Entry(previousCryptoRates).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        cryptoRates.changepercentage = Convert.ToDecimal(changePercentage);
                        context.CryptoRates.Add(cryptoRates);
                    }
                }
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
                //throw ex;
                //Log exception
            }
        }

        public CryptoRatesViewModel getCryptoRate(DataTableParams dataTableParams)
        {
            try
            {
                CryptoRatesViewModel cvm = new CryptoRatesViewModel();
                cvm.CryptoRatesList = context.CryptoRates.AsNoTracking().ToList();
                cvm.DataTableParams.totalRows = cvm.CryptoRatesList.Count();
                if (!string.IsNullOrEmpty(dataTableParams.searchValue))
                {
                    cvm.CryptoRatesList = cvm.CryptoRatesList.
                        Where(x => x.buy.ToLower().Contains(dataTableParams.searchValue.ToLower())).ToList();
                }
                cvm.DataTableParams.totalRowsAfterfiltering = cvm.CryptoRatesList.Count;
                cvm.CryptoRatesList = cvm.CryptoRatesList.Skip(dataTableParams.start).Take(dataTableParams.length).ToList();
                return cvm;
            }
            catch (Exception ex)
            {
                throw ex;
                //Log exception
            }
        }
    }
}
