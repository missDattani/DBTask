using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Repository
{
    public interface ICityInterface
    {
        List<CityModel> DisplayCities();
        City DisplayCityById(int? CtId);
        int InsCity(CityModel cityM,int? CtId);
        int RemoveCity(int CtId);

        IEnumerable<City> SelectCity(int Id); 
    }
}
