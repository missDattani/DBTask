using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Data.DBRepository.State
{
    public interface IStateRepository
    {
        Task<int> AddEditState(StateModel stateModel);
        Task<StateModel> GetStateById(int id);

        Task<List<StateModel>> GetAllStates();
    }
}
