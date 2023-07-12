using SchoolSystem326.Data.DBRepository.City;
using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.City
{
    internal class CityServices : ICityServices
    {
        #region Fields
        private readonly ICityRepository cityRepository;
        #endregion

        #region Constructor
        public CityServices(ICityRepository cityRepository) 
        {
            this.cityRepository = cityRepository;
        }
        #endregion

        #region Methods
        public async Task<int> AddEditCity(CityModel cityModel)
        {
            return await cityRepository.AddEditCity(cityModel);
        }

        public async Task<List<CityModel>> GetAllCities()
        {
            return await cityRepository.GetAllCities();
        }

        public async Task<CityModel> GetCityById(int id)
        {
            return await cityRepository.GetCityById(id);
        }

        public async Task<List<CityModel>> GetCityByStateId(int Id)
        {
            return await cityRepository.GetCityByStateId(Id);
        }

        public async Task<List<StateModel>> GetStateByCountryId(int id)
        {
            return await cityRepository.GetStateByCountry(id);
        }
        #endregion
    }
}
