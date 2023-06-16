using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Helpers.Helpers
{
    public class CountryHelper
    {
        public static List<CountryModel> BindCoModelListToList(List<Country> countries)
        {
            try
            {
                List<CountryModel> CoList = new List<CountryModel>();
                foreach (var item in countries)
                {
                    CountryModel coModel = new CountryModel();
                    coModel.CountryId = item.CountryId;
                    coModel.CountryName = item.CountryName;
                    CoList.Add(coModel);
                }
                return CoList;
            }
            catch (Exception e)
            {

                throw e;
            }
        } 

        public static Country BindCountryModelToCountry(CountryModel model)
        {
            try
            {
                Country co = new Country();
                co.CountryId = model.CountryId;
                co.CountryName = model.CountryName;
                return co;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static CountryModel BindCountryToCountryModel(Country country)
        {
            try
            {
                CountryModel coModel = new CountryModel();
                coModel.CountryId = country.CountryId;
                coModel.CountryName = country.CountryName;
                return coModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
