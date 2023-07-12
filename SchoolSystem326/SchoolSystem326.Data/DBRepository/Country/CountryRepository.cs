using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchoolSystem326.Common.Helper;
using SchoolSystem326.Model.Config;
using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Data.DBRepository.Country
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public CountryRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }
        #endregion


        #region Methods
        public async Task<int> AddEditCountry(CountryModel countryModel)
        {
           if(countryModel.CountryId == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CoId",null);
                parameter.Add("@CoName", countryModel.CountryName);
                return await ExecuteAsync<int>(StoredProcedures.InsertCountry,parameter,commandType:CommandType.StoredProcedure);
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CoId", countryModel.CountryId);
                parameter.Add("@CoName", countryModel.CountryName);
                return await ExecuteAsync<int>(StoredProcedures.InsertCountry, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<CountryModel>> GetAllCountry()
        {
            var country = await QueryAsync<CountryModel>(StoredProcedures.GetAllCountries, commandType:CommandType.StoredProcedure);
            return country.ToList();
        }

        public async Task<CountryModel> GetCountryById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CoId", id);
            return await QueryFirstOrDefaultAsync<CountryModel>(StoredProcedures.GetCountryById,parameter,commandType:CommandType.StoredProcedure);
        }
        #endregion
    }
}
