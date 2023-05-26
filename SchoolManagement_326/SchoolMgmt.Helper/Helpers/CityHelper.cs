using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt.Helper.Helpers
{
    public class CityHelper
    {
        public static City ConvertCityM(CityModel ct)
        {
            try
            {
                City city = new City();
                city.CiId = ct.CiId;
                city.CityName = ct.CityName;
                city.CoId = (int)ct.CoId;
                city.StId = (int)ct.StId;

                return city;
            }
            catch (Exception e) { throw e; }
        }

        public static CityModel ConvertCity(City ct)
        {
            try { 
            CityModel city = new CityModel();
            city.CiId = ct.CiId;
            city.CityName = ct.CityName;
            city.CoId = (int)ct.CoId;
            city.StId = (int)ct.StId;
        
            return city;
            }
            catch(Exception e) { throw e; }
        }
    }
}
