using SchoolSystem326.Data.DBRepository.State;
using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.State
{
    public class StateServices : IStateServices
    {
        #region Fields
        private readonly IStateRepository stateRepository;
        #endregion

        #region Constructor
        public StateServices(IStateRepository stateRepository) 
        { 
            this.stateRepository = stateRepository;
        }
        #endregion

        #region Methods
        public async Task<int> AddEditState(StateModel stateModel)
        {
           return await stateRepository.AddEditState(stateModel);
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
