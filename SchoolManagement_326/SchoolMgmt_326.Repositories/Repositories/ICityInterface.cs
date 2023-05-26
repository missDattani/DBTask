using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Repositories
{
    public interface ICityInterface
    {
        List<City> DisplayCities();

        City DisplayCityById(int CiId);

        int InsertCities(CityModel city);

        CityModel EditCity(int CiId);
        int EditCity(CityModel city);

        int RemoveCity(int CiId);

        IEnumerable<City> SelectCity(int CoId,int StId);
    }
}
