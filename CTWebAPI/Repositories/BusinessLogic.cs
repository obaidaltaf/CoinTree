using CTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTWebAPI.Controllers
{
    public class BusinessLogic : IBusinessLogic
    {
        IHelper _helper;
        IDataAccess _dataAccess;
        public BusinessLogic(IHelper helper, IDataAccess dataAccess)
        {
            _helper = helper;
            _dataAccess = dataAccess;
        }
        public async Task<List<CryptoRates>> GetCryptoRate()
        {
            try
            {
                var cryptoRatesList = await _helper.runAPI();
                return await _dataAccess.saveCryptoRate(cryptoRatesList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
