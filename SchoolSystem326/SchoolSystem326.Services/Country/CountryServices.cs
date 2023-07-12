using SchoolSystem326.Data.DBRepository.Country;
using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.Country
{
    public class CountryServices : ICountryServices
    {
        #region Fields
        private readonly ICountryRepository countryRepository;
        #endregion

        #region Constructor
        public CountryServices(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        #endregion

        #region Methods
        public async Task<int> AddEditCountry(CountryModel countryModel)
        {
           return await countryRepository.AddEditCountry(countryModel);
        }

        public async Task<List<CountryModel>> GetAllCountry()
        {
            return await countryRepository.GetAllCountry();
        }

        public async Task<CountryModel> GetCountryById(int id)
        {
           return await countryRepository.GetCountryById(id);
        }
        #endregion
    }
}
