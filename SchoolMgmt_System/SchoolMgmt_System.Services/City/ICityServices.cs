using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services.City
{
    public interface ICityServices
    {
        Task<List<CityModel>> GetAllCity();
        Task<CityModel> GetCityById(int id);

        Task<int> AddEditCity(CityModel cityModel);
        Task<List<StateModel>> GetStateByCountry(int Id);
        // Task<int> DeleteCity(int id);
    }
}
