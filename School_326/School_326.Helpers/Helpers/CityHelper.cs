using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Helpers.Helpers
{
    public class CityHelper
    {
        public static City ConvertCity(CityModel cityM)
        {
            City ct = new City();
            ct.CiId = cityM.CiId;
            ct.CityName = cityM.CityName;
            ct.CoId = cityM.CoId;
            ct.StId = cityM.StId;
            return ct;
        }

        public static CityModel ConvertCityM(City city)
        {
            CityModel ctM = new CityModel();
            ctM.CiId = city.CiId;
            ctM.CityName = city.CityName;
            ctM.CoId = (int)city.CoId;
            ctM.StId = (int)city.StId;
            return ctM;
        }
    }
}
