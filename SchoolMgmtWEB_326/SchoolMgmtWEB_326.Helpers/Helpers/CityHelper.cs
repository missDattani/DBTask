
using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Helpers.Helpers
{
   public class CityHelper
    {
        public static List<CityModel> BindCtModelListToList(List<City> cities)
        {
            try
            {
                List<CityModel> ctList = new List<CityModel>();
                foreach (var item in cities)
                {
                    CityModel ctModel = new CityModel();
                    ctModel.CityId = item.CityId;
                    ctModel.CityName = item.CityName;
                    ctModel.StateId = item.StateId;
                    ctModel.CountryId = item.CountryId;
                    ctModel.StateName = item.States.StateName;
                    ctModel.CountryName = item.Country.CountryName;
                    ctList.Add(ctModel);
                }
                return ctList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static City BindCityModelToCity(CityModel ctModel)
        {
            try
            {
                City city = new City();
                city.CityId = ctModel.CityId;
                city.CityName = ctModel.CityName;
                city.StateId = ctModel.StateId;
                city.CountryId = ctModel.CountryId;
          
                return city;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static CityModel BindCityModelToCity(City city)
        {
            try
            {
                CityModel ctModel = new CityModel();
                ctModel.CityId = city.CityId;
                ctModel.CityName = city.CityName;
                ctModel.StateId = city.StateId;
                ctModel.CountryId = city.CountryId;
                ctModel.StateName = city.States.StateName;
                ctModel.CountryName = city.Country.CountryName;
                return ctModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
