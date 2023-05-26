using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Helpers.Helpers
{
    public class StateHelper
    {
        public static State ConvertState(StateModel stateM)
        {
            State state = new State();
            state.StId = stateM.StId;
            state.StateName = stateM.StateName;
            state.CoId = stateM.CoId;
            return state;
        }

        public static StateModel ConvertStateM(State state)
        {
            StateModel stateM = new StateModel();
            stateM.StId = state.StId;
            stateM.StateName = state.StateName;
            stateM.CoId = (int)state.CoId;
            return stateM;
        }
    }
}
