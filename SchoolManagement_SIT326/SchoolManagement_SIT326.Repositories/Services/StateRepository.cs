using SchoolManagement_SIT326.Helpers.Helpers;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using SchoolManagement_SIT326.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Services
{
    public class StateRepository : IStateInterface
    {
        private readonly OrderManagementEntities entities = new OrderManagementEntities();


        public List<StateModel> DisplayStates()
        {
            try
            {
                List<States> states = entities.States.ToList();
                if (states != null && states.Count() > 0)
                {
                    List<StateModel> sModel = StateHelper.BindStModelListToList(states);
                    return sModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public States DisplayStateById(int? StId)
        {
            try
            {
                States states = entities.States.Where(m => m.StateId == StId).FirstOrDefault();
                if (states != null)
                {
                    
                    return states;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int InsStates(StateModel stModel,int? StId)
        {
            try
            {
                States st = StateHelper.BindStateModelToState(stModel);
               if(StId == 0) 
                {
                    var checkSt = entities.States.Any(m => m.StateName == stModel.StateName);
                    if (checkSt)
                    {
                        return 0;
                    }
                    else
                    {

                    entities.States.Add(st);
                    entities.SaveChanges();
                    return 1;
                    }
                }
                else
                {
                    entities.Entry(st).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int RemoveState(int StId)
        {
            try
            {
                var res = entities.States.Where(m => m.StateId == StId).FirstOrDefault();
                if (res != null)
                {
                    entities.States.Remove(res);
                    entities.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<States> SelectStates(int CoId)
        {
            try
            {
                return entities.States.Where(m => m.CountryId == CoId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
