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
    public class CountryServices : ICountryInterface
    {
        private Pooja_SchoolMgmt_326Entities2 entities = new Pooja_SchoolMgmt_326Entities2();

        public List<Country> DisplayCountries()
        {try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Countries.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public Country DisplayCountryById(int id)
        {
            try
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var country = entities.Countries.Where(m => m.CoId == id).FirstOrDefault();
                return country;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CountryModel EditCountry(int CoId)
        {
            try { 
            Country c1 = entities.Countries.Find(CoId);
            CountryModel c3 = CountryHelper.ConvertCountry(c1);
            return c3;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int EditCountry(CountryModel country)
        {try
            {
                entities.sp_AddEditCountry(country.CoId, country.CountryName);
                entities.SaveChanges();
                return 1;
            }
            catch (Exception e) { throw e; }
        }

        public int InsertCountry(CountryModel country)
        {try
            {
                var checkCo = entities.Countries.Any(m => m.CountryName == country.CountryName);
                if (checkCo)
                {
                    return 0;
                }
                else
                {
                    entities.sp_AddEditCountry(null, country.CountryName);
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Country> SelectCountry()
        {
            try { 
               return entities.Countries.ToList();
            }
            catch(Exception e) { throw e; }
        }

        public int DeleteCountry(int CoId)
        {
            try
            {
                var res = entities.Countries.Where(x => x.CoId == CoId).FirstOrDefault();
                bool check = (entities.Cities.Any(x => x.CoId == CoId) && entities.States.Any(x => x.CoId == CoId));
                if (check)
                {
                    return 0;
                }
                entities.Countries.Remove(res);
                entities.SaveChanges();
                return 1;
            }catch(Exception e) { throw e; }
        }



    }
}
