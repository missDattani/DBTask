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

namespace SchoolMgmt_System.Data.DBrepository.State
{
    public class StateRepository : BaseRepository, IStateRepository
    {
        #region Fields
        public IConfiguration configuration;

        #endregion
        #region Constructor
        public StateRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        public async Task<int> AddEditStates(StateModel stateModel)
        {
            if (stateModel.StId == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ID", null);
                parameter.Add("@StateName", stateModel.StateName);
                parameter.Add("@CountryID", stateModel.CoId);
                return await ExecuteAsync<int>(StoredProcedures.InsertState, parameter, commandType: CommandType.StoredProcedure);
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ID", stateModel.StId);
                parameter.Add("@StateName", stateModel.StateName);
                parameter.Add("@CountryID", stateModel.CoId);
                return await ExecuteAsync<int>(StoredProcedures.InsertState, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteState(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            return await ExecuteAsync<int>(StoredProcedures.DeleteState, parameter, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<StateModel>> GetAllStates()
        {
            var data = await QueryAsync<StateModel>(StoredProcedures.StateList,commandType : CommandType.StoredProcedure); 
            return data.ToList();
        }

      

        public async Task<StateModel> GetStateById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            return await QueryFirstOrDefaultAsync<StateModel>(StoredProcedures.GetStateById, parameter,commandType : CommandType.StoredProcedure);
        }
    }
}
