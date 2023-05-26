using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Repositories
{
    public interface IStateInterface
    {
        List<State> DisplayStates();

        State DisplayStateById(int StId);
        int InsertState(StateModel state);
        StateModel EditState(int StId);
        int EditState(StateModel state);

        IEnumerable<State> SelectStates(int CoId);

        int RemoveState(int StId);
    }
}
