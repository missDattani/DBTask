using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchoolMgmt_System.Model.Config;
using SchoolMgmt_System.Model.ViewModels;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMgmt_System.Common.Helpers;
using Dapper;

namespace SchoolMgmt_System.Data.DBrepository.Country
{
    public class CountryRepository : BaseRepository, ICountryRepository
	{
		#region Fields
		public IConfiguration configuration;
		#endregion

		#region Constructor
		public CountryRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
		{
			this.configuration = configuration;
		}

		#endregion

		#region Methods
		public async Task<List<CountryModel>> GetAllCountries()
		{
			var data = await QueryAsync<CountryModel>(StoredProcedures.CountryList,commandType:CommandType.StoredProcedure);
			return data.ToList();
		}
		public async Task<int> AddEditCountry(CountryModel countryModel)
		{
			if(countryModel.CoId == 0)
			{
				var parameter = new DynamicParameters();
				parameter.Add("@Id", null);
				parameter.Add("@CountryName", countryModel.CountryName);
				return await ExecuteAsync<int>(StoredProcedures.InsertCountry, parameter,commandType:CommandType.StoredProcedure);
			}
			else
			{
				var parameter = new DynamicParameters();
				parameter.Add("@Id", countryModel.CoId);
				parameter.Add("@CountryName", countryModel.CountryName);
				return await ExecuteAsync<int>(StoredProcedures.InsertCountry, parameter, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task<CountryModel> GetCountryById(int id)
		{
			var parameter = new DynamicParameters();
			parameter.Add("@Id", id);
			return await QueryFirstOrDefaultAsync<CountryModel>(StoredProcedures.GetCountryById, parameter ,commandType:CommandType.StoredProcedure);
		}

        public async Task<int> DeleteCountry(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
			var data = await ExecuteAsync<int>(StoredProcedures.DeleteCountry, parameter, commandType: CommandType.StoredProcedure);
			return data;
        }

        public async Task<List<CountryModel>> GetCountryDataTable(string sortColumn, string sortDirection, int offSetVal, int pageSize, string searchBy)
        {
			var parameter = new DynamicParameters();
			parameter.Add("@sortColumn", sortColumn);
			parameter.Add("@sortOrder", sortDirection);
			parameter.Add("@offSetVal", offSetVal);
			parameter.Add("@pageSize", pageSize);
			parameter.Add("@searchText", searchBy);
			var data = await QueryAsync<CountryModel>(StoredProcedures.CountryDataTable,parameter, commandType: CommandType.StoredProcedure);
			return data.ToList();
        }

        #endregion
    }
}
