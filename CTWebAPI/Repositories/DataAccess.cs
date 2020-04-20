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

        public async Task<List<CryptoRates>> saveCryptoRate(List<CryptoRates> cryptoRatesList)
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
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //throw ex;
                //Log exception
            }
            return context.CryptoRates.AsNoTracking().ToList();
        }
    }
}
