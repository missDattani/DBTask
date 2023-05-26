using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Repository
{
    public interface ICityInterface
    {
        List<City> DisplayCities();
        City DisplayCityById(int CiId);

        int InsertCity(CityModel cityM);

        IEnumerable<City> SelectCities(int CoId,int StId);

        int EditCity(CityModel cityM);
        CityModel EditCity(int CiId);

        int RemoveCity(int CiId);
    }
}
