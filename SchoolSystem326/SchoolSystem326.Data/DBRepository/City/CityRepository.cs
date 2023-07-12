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

namespace SchoolSystem326.Data.DBRepository.City
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public CityRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig):base(dataConfig,configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        public async Task<int> AddEditCity(CityModel cityModel)
        {
           if(cityModel.CityId == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CiId", null);
                parameter.Add("@CiName", cityModel.CityName);
                parameter.Add("@StId", cityModel.StateId);
                parameter.Add("@CoId",cityModel.CountryId);
                return await ExecuteAsync<int>(StoredProcedures.InsertCity, parameter, commandType: CommandType.StoredProcedure);
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CiId", cityModel.CityId);
                parameter.Add("@CiName", cityModel.CityName);
                parameter.Add("@StId", cityModel.StateId);
                parameter.Add("@CoId", cityModel.CountryId);
                return await ExecuteAsync<int>(StoredProcedures.InsertCity, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<CityModel>> GetAllCities()
        {
            var city = await QueryAsync<CityModel>(StoredProcedures.GetAllCities, commandType: CommandType.StoredProcedure);
            return city.ToList();
        }

        public async Task<CityModel> GetCityById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CiId", id);
            return await QueryFirstOrDefaultAsync<CityModel>(StoredProcedures.GetCityById,parameter, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<CityModel>> GetCityByStateId(int Id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@StId", Id);
            var data = await QueryAsync<CityModel>(StoredProcedures.GetCityByStateId, parameter, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        public async Task<List<StateModel>> GetStateByCountry(int Id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CoId", Id);
            var data = await QueryAsync<StateModel>(StoredProcedures.GetStateByCountryid, parameter, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
