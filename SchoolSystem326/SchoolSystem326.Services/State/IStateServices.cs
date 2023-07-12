using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.State
{
    public interface IStateServices
    {
        Task<int> AddEditState(StateModel stateModel);

        Task<StateModel> GetStateById(int id);

        Task<List<StateModel>> GetAllStates();
    }
}
