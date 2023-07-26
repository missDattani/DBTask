using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchoolMgmt_System.Common.Helpers;
using SchoolMgmt_System.Model.Config;
using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace SchoolMgmt_System.Data.DBrepository.City
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public CityRepository(IConfiguration configuration, IOptions<DataConfig> dataConfig) :base(dataConfig, configuration) 
        {
            this.configuration = configuration;
        }
     
        #endregion
        public async Task<int> AddEditCity(CityModel cityModel)
        {
            if(cityModel.CiId == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", null);
                parameter.Add("@CityName", cityModel.CityName);
                parameter.Add("@StId", cityModel.StId);
                parameter.Add("@CoId", cityModel.CoId);
                return await ExecuteAsync<int>(StoredProcedures.InsertCity, parameter,commandType: CommandType.StoredProcedure);
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", cityModel.CiId);
                parameter.Add("@CityName", cityModel.CityName);
                parameter.Add("@StId", cityModel.StId);
                parameter.Add("@CoId", cityModel.CoId);
                return await ExecuteAsync<int>(StoredProcedures.InsertCity, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        //public Task<int> DeleteCity(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<CityModel>> GetAllCity()
        {
            var data = await QueryAsync<CityModel>(StoredProcedures.CityList, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        public async Task<CityModel> GetCityById(int Id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", Id);
            return await QueryFirstOrDefaultAsync<CityModel>(StoredProcedures.GetCityById, parameter ,commandType: CommandType.StoredProcedure);
        }

        public async Task<List<StateModel>> GetStateByCountry(int Id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", Id);
            var data = await QueryAsync<StateModel>(StoredProcedures.GetStateByCountryId, parameter, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
