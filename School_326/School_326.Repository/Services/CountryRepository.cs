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
    public class CountryRepository:ICountryInterface
    {
        DBTempEntitiesNew entities = new DBTempEntitiesNew();

        public List<Country> DiplayCountries()
        {
            try { 
            entities.Configuration.ProxyCreationEnabled = false;
            return entities.Countries.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Country DisplayCountryById(int id)
        {
            try {
                entities.Configuration.ProxyCreationEnabled = false;
                var country = entities.Countries.Where(m => m.CoId == id).FirstOrDefault();
            return country;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int InsertCountry(CountryModel country)
        {
            try
            {
                var CheckCo = entities.Countries.Any(m => m.CountryName == country.CountryName);
                if (CheckCo)
                {
                    return 0;
                }
                else
                {
                    Country co = CountryHelper.ConvertCountry(country);
                    entities.Countries.Add(co);
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int EditCountry(CountryModel CoModel)
        {
            Country country = CountryHelper.ConvertCountry(CoModel);
            entities.Entry(country).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            return 1;
        }

        public CountryModel EditCountry(int CoId)
        {
            Country country = entities.Countries.Find(CoId);
            CountryModel countryM = CountryHelper.ConvertCountryM(country);
            entities.SaveChanges();
            return countryM;
        }

        public int RemoveCountry(int CoId)
        {
            var res = entities.Countries.Where(m => m.CoId == CoId).FirstOrDefault();
            entities.Countries.Remove(res);
            entities.SaveChanges();
            return 1;
        }

        public IEnumerable<Country> SelectCountry()
        {
            try
            {
                return entities.Countries.ToList();
            }
            catch (Exception e) { throw e; }
        }

       
    }
}
