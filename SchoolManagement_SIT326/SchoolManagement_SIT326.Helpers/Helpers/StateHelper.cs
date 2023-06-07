using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Helpers.Helpers
{
    public class StateHelper
    {
        public static List<StateModel> BindStModelListToList(List<States> states)
        {
            try
            {
                List<StateModel> stList = new List<StateModel>();
                foreach (var item in states)
                {
                    StateModel st = new StateModel();
                    st.StateId = item.StateId;
                    st.StateName = item.StateName;
                    st.CountryId = item.CountryId;
                    st.CountryName = item.Country.CountryName;
                    stList.Add(st);
                }
                return stList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static States BindStateModelToState(StateModel stModel)
        {
            try
            {
                States st = new States();
                st.StateId = stModel.StateId;
                st.StateName = stModel.StateName;
                st.CountryId = stModel.CountryId;
           
                return st;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static StateModel BindStateToStateModel(States states)
        {
            try
            {
                StateModel sModel = new StateModel();
                sModel.StateId = states.StateId;
                sModel.StateName = states.StateName;
                sModel.CountryId = states.CountryId;
                sModel.CountryName = states.Country.CountryName;
                return sModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
