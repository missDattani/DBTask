using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt.Helper.Helpers
{
    public class StateHelper
    {
        public static StateModel ConvertState(State st)
        {try
            {
                StateModel state = new StateModel();
                state.StId = st.StId;
                state.StateName = st.StateName;
                state.CoId = (int)st.CoId;
                return state;
            }
            catch (Exception e) { throw e; }
        }

    }
}
