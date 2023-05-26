using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Repository
{
    public interface ICountryInterface
    {
        List<Country> DiplayCountries();

        Country DisplayCountryById(int CoId);

        int InsertCountry(CountryModel country);

        int EditCountry(CountryModel CoModel);
        CountryModel EditCountry(int CoId);
        int RemoveCountry(int CoId);
        IEnumerable<Country> SelectCountry();
    }
}
