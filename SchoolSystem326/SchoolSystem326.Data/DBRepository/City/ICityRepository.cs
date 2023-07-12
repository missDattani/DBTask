using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Data.DBRepository.City
{
    public interface ICityRepository
    {
        Task<int> AddEditCity(CityModel cityModel);
        Task<CityModel> GetCityById(int id);

        Task<List<StateModel>> GetStateByCountry(int Id);

        Task<List<CityModel>> GetAllCities();
        Task<List<CityModel>> GetCityByStateId(int Id);
    }
}
