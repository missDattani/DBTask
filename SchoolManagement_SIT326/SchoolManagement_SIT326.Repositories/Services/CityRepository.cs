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
    public class CityRepository : ICityInterface
    {
        private readonly OrderManagementEntities entities = new OrderManagementEntities();
        public List<CityModel> DisplayCities()
        {
            try
            {
                List<City> ctList = entities.City.ToList();
                if (ctList != null && ctList.Count() > 0)
                {
                    List<CityModel> ctModel = CityHelper.BindCtModelListToList(ctList);
                    return ctModel;
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

        public City DisplayCityById(int? CtId)
        {
            try
            {
                City city = entities.City.Where(m => m.CityId == CtId).FirstOrDefault();
                if (city != null)
                {
                  
                    return city;
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

        public int InsCity(CityModel cityM,int? CtId)
        {
            try
            {
                City city = CityHelper.BindCityModelToCity(cityM);
                if(CtId == 0)
                {
                    var checkCt = entities.City.Any(m => m.CityName == cityM.CityName);
                    if (checkCt)
                    {
                        return 0;
                    }
                    else
                    { 
                        entities.City.Add(city);
                        entities.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(city).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return 1;
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }

      
        public IEnumerable<City> SelectCity(int Id)
        {
            try
            {
                return entities.City.Where(m => m.StateId == Id).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public int RemoveCity(int CtId)
        {
            try
            {
                var res = entities.City.Where(m => m.CityId == CtId).FirstOrDefault();
                if (res != null)
                {
                    entities.City.Remove(res);
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

    }
}
