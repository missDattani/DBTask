using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Repositories
{
    public interface ICountryInterface
    {
        List<Country> DisplayCountries();
        Country DisplayCountryById(int CoId);
        int InsertCountry(CountryModel country);

        CountryModel EditCountry(int CoId);
        int EditCountry(CountryModel country);

        IEnumerable<Country> SelectCountry();

        int DeleteCountry(int CoId);
    }
}
