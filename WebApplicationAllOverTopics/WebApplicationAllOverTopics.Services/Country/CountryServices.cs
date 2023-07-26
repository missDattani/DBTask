using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Data.DBRepository.Country;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Services.Country
{
    public class CountryServices : ICountryServices
    {
        #region Fields
        public readonly ICountryRepository countryRepository;
        #endregion

        #region Constructor
        public CountryServices(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        #endregion

        #region Methods
        public async Task<List<CountryModel>> GetCountries()
        {
           return await countryRepository.GetCountries();
        }

        #endregion
    }
}
