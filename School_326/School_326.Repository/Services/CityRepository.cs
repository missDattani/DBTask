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
    public class CityRepository:ICityInterface
    {
        DBTempEntitiesNew entities = new DBTempEntitiesNew();
        public List<City> DisplayCities()
        {
            entities.Configuration.ProxyCreationEnabled = false;
            return entities.Cities.ToList();
        }

        public City DisplayCityById(int CiId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            var ct = entities.Cities.Where(m => m.CiId == CiId).FirstOrDefault();
            return ct;
        }

        public int InsertCity(CityModel cityM)
        {
            var CheckCt = entities.Cities.Any(m => m.CityName == cityM.CityName);
            if (CheckCt)
            {
                return 0;
            }
            else
            {
                City city = CityHelper.ConvertCity(cityM);
                entities.Cities.Add(city);
                entities.SaveChanges();
                return 1;
            }
        }

        public IEnumerable<City> SelectCities(int CoId, int StId)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            return entities.Cities.Where(m => m.CoId == CoId && m.StId == StId).ToList();
        }

        public int EditCity(CityModel cityM)
        {
            City ct = CityHelper.ConvertCity(cityM);
            entities.Entry(ct).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return 1;
        }

        public CityModel EditCity(int CiId)
        {
            City city = entities.Cities.Find(CiId);
            CityModel cityM = CityHelper.ConvertCityM(city);
            entities.SaveChanges();
            return cityM;
        }

        public int RemoveCity(int CiId)
        {
            var res = entities.Cities.Where(m => m.CiId == CiId).FirstOrDefault();
            entities.Cities.Remove(res);
            entities.SaveChanges();
            return 1;
        }

       
    }
}
