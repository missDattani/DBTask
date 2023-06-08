using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Repository
{
    public interface ICountryInterface
    {
        List<CountryModel> DisplayCountries();
        CountryModel DisplayCountryById(int? CoId);
        int InsCountries(CountryModel country,int? CoId);
        int RemoveCountry(int CoId);

        IEnumerable<Country> SelectCountry();
       
    }
}
