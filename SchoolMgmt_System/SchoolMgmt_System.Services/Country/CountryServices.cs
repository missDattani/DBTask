using SchoolMgmt_System.Data.DBrepository.Country;
using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services.Country
{
    public class CountryServices : ICountryServices
	{
		#region Fields
		private ICountryRepository coRepository;
		#endregion

		#region Constructor
		public CountryServices(ICountryRepository coRepository)
		{
			this.coRepository = coRepository;
		}
		#endregion

		#region Methods
		public async Task<List<CountryModel>> GetAllCountries()
		{
			return await coRepository.GetAllCountries();
		}

		public async Task<int> AddEditCountry(CountryModel countryModel)
		{
			return await coRepository.AddEditCountry(countryModel);
		}

		public async Task<CountryModel> GetCountryById(int id)
		{
			return await coRepository.GetCountryById(id);
		}

        public async Task<int> DeleteCountry(int id)
        {
            return await coRepository.DeleteCountry(id);
        }

        public async Task<List<CountryModel>> GetCountryDataTable(string sortColumn, string sortDirection, int offSetVal, int pageSize, string searchBy)
        {
            return await coRepository.GetCountryDataTable(sortColumn, sortDirection, offSetVal, pageSize, searchBy);
        }


        #endregion
    }
}
