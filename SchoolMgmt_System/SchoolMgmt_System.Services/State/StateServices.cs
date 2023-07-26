using SchoolMgmt_System.Data.DBrepository.State;
using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services.State
{
    public class StateServices : IStateServices
    {
        #region Fields
        private IStateRepository stateRepository;
        #endregion

        #region Constructor
        public StateServices(IStateRepository stateRepository) 
        {
            this.stateRepository = stateRepository;
        }
        #endregion

        #region Method
        public async Task<int> AddEditStates(StateModel stateModel)
        {
            return await stateRepository.AddEditStates(stateModel);
        }

        public async Task<int> DeleteState(int id)
        {
            return await stateRepository.DeleteState(id);
        }

        public async Task<List<StateModel>> GetAllStates()
        {
            return await stateRepository.GetAllStates();
        }

       

        public async Task<StateModel> GetStateById(int id)
        {
            return await stateRepository.GetStateById(id);
        }
        #endregion
    }
}
