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
    public class CityServices : ICityInterface
    {
        private Pooja_SchoolMgmt_326Entities2 entities = new Pooja_SchoolMgmt_326Entities2();

   
        public List<City> DisplayCities()
        {try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Cities.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public City DisplayCityById(int CiId)
        {
            try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var ct = entities.Cities.Where(m => m.CiId == CiId).FirstOrDefault();
                return ct;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int InsertCities(CityModel city)
        {
            try { 
            var checkCi = entities.Cities.Any(m => m.CityName == city.CityName);
            if (checkCi)
            {
                return 0;
            }
            else
            {
                   
                    City ct = CityHelper.ConvertCityM(city);
                    entities.Cities.Add(ct);
                    entities.SaveChanges();
                return 1;
            }
            }
            catch(Exception e) { throw e; }
        }

        public CityModel EditCity(int CiId)
        {
            try
            {
                City ct = entities.Cities.Find(CiId);
                CityModel ctm = CityHelper.ConvertCity(ct);
                return ctm;
            }
            catch (Exception e) { throw e; }
        }

        public int EditCity(CityModel city)
        {
            try { 
            entities.sp_AddEditCities(city.CiId, city.CityName, city.CoId, city.StId);
            entities.SaveChanges();
            return 1;
            }
            catch(Exception e) { throw e; }
        }

        public IEnumerable<City> SelectCity(int CoId,int StId)
        {
            try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Cities.Where(m => m.StId == StId && m.CoId == CoId).ToList();
            }
            catch (Exception e) { throw e; }
        }

        public int RemoveCity(int CiId)
        {
            try
            {
                var res = entities.Cities.Where(x => x.CiId == CiId).FirstOrDefault();
                bool check = (entities.Students.Any(x => x.CityId == CiId) && entities.Teachers.Any(x => x.CityId == CiId));
                if (check) {
                    return 0;
                }
               
                    entities.Cities.Remove(res);
                    entities.SaveChanges();
                    return 1;
                
            }
            catch (Exception e) { throw e; }
        }


    }
}
