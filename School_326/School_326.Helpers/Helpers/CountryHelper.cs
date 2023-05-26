using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Helpers.Helpers
{
    public class CountryHelper
    {
        public static Country ConvertCountry(CountryModel countryM)
        {
            Country country = new Country();
            country.CoId = countryM.CoId;
            country.CountryName = countryM.CountryName;
            return country;
        }

        public static CountryModel ConvertCountryM(Country Co)
        {
            CountryModel countryM = new CountryModel();
            countryM.CoId = Co.CoId;
            countryM.CountryName = Co.CountryName;
            return countryM;
        }

      
    }
}
