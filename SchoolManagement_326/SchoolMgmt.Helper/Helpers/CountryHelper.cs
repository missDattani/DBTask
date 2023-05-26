using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt.Helper.Helpers
{
    public class CountryHelper
    {

        public static CountryModel ConvertCountry(Country country)
        {
            try
            {
                CountryModel count = new CountryModel();
                count.CoId = country.CoId;
                count.CountryName = country.CountryName;
                return count;
            }
            catch (Exception e) { throw e; }
        }
        }
      
    }

