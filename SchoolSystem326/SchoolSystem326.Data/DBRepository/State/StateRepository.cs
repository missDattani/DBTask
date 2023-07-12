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

namespace SchoolSystem326.Data.DBRepository.State
{
    public class StateRepository : BaseRepository, IStateRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public StateRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig,configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task<int> AddEditState(StateModel stateModel)
        {
            if(stateModel.StateId == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@StId", null);
                parameter.Add("@StName", stateModel.StateName);
                parameter.Add("@CoId", stateModel.CountryId);
                return await ExecuteAsync<int>(StoredProcedures.InsertState, parameter, commandType: CommandType.StoredProcedure);
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@StId", stateModel.StateId);
                parameter.Add("@StName", stateModel.StateName);
                parameter.Add("@CoId", stateModel.CountryId);
                return await ExecuteAsync<int>(StoredProcedures.InsertState, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<StateModel>> GetAllStates()
        {
            var state = await QueryAsync<StateModel>(StoredProcedures.GetAllStates, commandType: CommandType.StoredProcedure); 
            return state.ToList();
        }

        public async Task<StateModel> GetStateById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@StId", id);
            return await QueryFirstOrDefaultAsync<StateModel>(StoredProcedures.GetStateById,parameter, commandType: CommandType.StoredProcedure);
        }
        #endregion
    }
}
