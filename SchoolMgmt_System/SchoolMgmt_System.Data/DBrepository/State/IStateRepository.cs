using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Data.DBrepository.State
{
    public interface IStateRepository
    {
        Task<List<StateModel>> GetAllStates();
        Task<StateModel> GetStateById(int id);
        Task<int> AddEditStates(StateModel stateModel);
        Task<int> DeleteState(int id);

        
    }
}
