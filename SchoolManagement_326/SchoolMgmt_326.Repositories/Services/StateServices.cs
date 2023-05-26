using SchoolMgmt.Helper.Helpers;
using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Services
{
    public class StateServices : IStateInterface
    {
        private Pooja_SchoolMgmt_326Entities2 entities = new Pooja_SchoolMgmt_326Entities2();

        public List<State> DisplayStates()
        {
            try {
                entities.Configuration.ProxyCreationEnabled = false;
            return entities.States.ToList();
            }
            catch(Exception e) { throw e; }
        }

        public State DisplayStateById(int StId)
        {
            try
            {
                entities.Configuration.ProxyCreationEnabled = false;

                var st = entities.States.Where(m => m.StId == StId).FirstOrDefault();
                return st;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int InsertState(StateModel state)
        {
            try { 
            var checkSt = entities.States.Any(m => m.StateName == state.StateName);
            if (checkSt)
            {
                return 0;
            }
            else
            {
                entities.sp_AddEditState(null, state.StateName,state.CoId);
                entities.SaveChanges();
                return 1;
            }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public StateModel EditState(int StId)
        {
            try { 
            State st = entities.States.Find(StId);
            StateModel stm = StateHelper.ConvertState(st);
            return stm;
            }
            catch(Exception e) { throw e; }
        }

        public int EditState(StateModel state)
        {
            try { 
            entities.sp_AddEditState(state.StId, state.StateName,state.CoId);
            entities.SaveChanges();
            return 1;
            }
            catch(Exception e) { throw e; }
        }

        public IEnumerable<State> SelectStates(int CoId)
        {try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.States.Where(m => m.CoId == CoId).ToList();
            }
            catch (Exception e) { throw e; }
        }

        public int RemoveState(int StId)
        {
            try
            {
                var res = entities.States.Where(x => x.StId == StId).FirstOrDefault();
                bool check = entities.Cities.Any(x => x.StId == StId);
                if (check)
                {
                    return 0;
                }
                entities.States.Remove(res);
                entities.SaveChanges();
                return 1;
            }
            catch (Exception e) { throw e; }
        }

    }
}
