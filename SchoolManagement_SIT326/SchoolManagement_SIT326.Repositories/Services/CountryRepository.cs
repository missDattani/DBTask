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
    public class CountryRepository : ICountryInterface
    {
        private readonly OrderManagementEntities entities = new OrderManagementEntities();
        public List<CountryModel> DisplayCountries()
        {
            try
            {
                List<Country> coList = entities.Country.ToList();
                if (coList != null && coList.Count() > 0)
                {
                    List<CountryModel> coModel = CountryHelper.BindCoModelListToList(coList);
                    return coModel;
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

        public Country DisplayCountryById(int? CoId)
        {
            try
            {
                Country country = entities.Country.Where(m => m.CountryId == CoId).FirstOrDefault();
                if (country != null)
                {
                    return country;
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

        public int InsCountries(CountryModel country,int? CoId)
        {
            try
            {

                Country country1 = CountryHelper.BindCountryModelToCountry(country);
                if (CoId == 0)
                {
                    var checkCo = entities.Country.Any(m => m.CountryName == country.CountryName);
                    if (checkCo)
                    {
                        return 0;
                    }
                    else 
                    { 
                        entities.Country.Add(country1);
                        entities.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(country1).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int RemoveCountry(int CoId)
        {
            try
            {
                var res = entities.Country.Where(m => m.CountryId == CoId).FirstOrDefault();
                if (res != null)
                {
                    entities.Country.Remove(res);
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

        public IEnumerable<Country> SelectCountry()
        {
            try
            {

                return entities.Country.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
