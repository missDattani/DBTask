using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Repository
{
    public interface IStateInterface
    {
        List<StateModel> DisplayStates();
        StateModel DisplayStateById(int? StId);
        int InsStates(StateModel stModel, int? StId);
        int RemoveState(int StId);

        IEnumerable<States> SelectStates(int CoId);
    }
}
