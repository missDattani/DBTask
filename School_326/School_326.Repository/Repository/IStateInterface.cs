using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Repository
{
    public interface IStateInterface
    {
        List<State> DisplayStates();
        State DisplayStateById(int StId);

        int InsertState(StateModel state);

        IEnumerable<State> SelectStates(int CoId);

        int EditState(StateModel StModel);
        StateModel EditState(int StId);

        int RemoveState(int StId);
    }
}
