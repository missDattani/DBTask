using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.City
{
    public interface ICityServices
    {
        Task<int> AddEditCity(CityModel cityModel);

        Task<CityModel> GetCityById(int id);

        Task<List<CityModel>> GetAllCities();
        Task<List<StateModel>> GetStateByCountryId(int id);

        Task<List<CityModel>> GetCityByStateId(int Id);

    }
}
