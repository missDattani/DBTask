using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Data.DBrepository.Country
{
	public interface ICountryRepository
	{
		Task<List<CountryModel>> GetAllCountries();

		Task<int> AddEditCountry(CountryModel countryModel);

		Task<CountryModel> GetCountryById(int id);

		Task<int> DeleteCountry(int id);

		Task<List<CountryModel>> GetCountryDataTable(string sortColumn,string sortDirection,int offSetVal,int pageSize,string searchBy);
	}
}
