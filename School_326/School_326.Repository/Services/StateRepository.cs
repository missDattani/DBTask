using School_326.Helpers.Helpers;
using School_326.Models.Context;
using School_326.Models.Models;
using School_326.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Services
{
    public class StateRepository:IStateInterface
    {
        DBTempEntitiesNew entities = new DBTempEntitiesNew();
        public List<State> DisplayStates()
        {
            try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.States.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public State DisplayStateById(int StId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            var st = entities.States.Where(m => m.StId == StId).FirstOrDefault();
            return st;
        }


        public int InsertState(StateModel stateM)
        {
            var CheckSt = entities.States.Any(m => m.StateName == stateM.StateName);
            if (CheckSt)
            {
                return 0;
            }
            else
            {
                State state = StateHelper.ConvertState(stateM);
                entities.States.Add(state);
                entities.SaveChanges();
                return 1;
            }
        }

        public IEnumerable<State> SelectStates(int CoId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            return entities.States.Where(m => m.CoId == CoId).ToList();
        }

        public int EditState(StateModel StModel)
        {
            State st = StateHelper.ConvertState(StModel);
            entities.Entry(st).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return 1;
        }

        public StateModel EditState(int StId)
        {
            State st = entities.States.Find(StId);
            StateModel stateM = StateHelper.ConvertStateM(st);
            entities.SaveChanges();
            return stateM;
        }

        public int RemoveState(int StId)
        {
            var res = entities.States.Where(m => m.StId == StId).FirstOrDefault();
            entities.States.Remove(res);
            entities.SaveChanges();
            return 1;
        }
    }
}
