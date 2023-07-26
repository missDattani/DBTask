using SchoolMgmt_System.Data.DBrepository.City;
using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services.City
{
    public class CityServices : ICityServices
    {
        #region Fields
        ICityRepository cityRepository;
        #endregion

        #region Constructor
        public CityServices(ICityRepository cityRepository) 
        {
            this.cityRepository = cityRepository;
        }
        #endregion
        public async Task<int> AddEditCity(CityModel cityModel)
        {
           return await cityRepository.AddEditCity(cityModel);
        }

        //public async Task<int> DeleteCity(int id)
        //{
        //   return await cityRepository.DeleteCity(id);
        //}

        public async Task<List<CityModel>> GetAllCity()
        {
            return await cityRepository.GetAllCity();
        }

        public async Task<CityModel> GetCityById(int id)
        {
            return await cityRepository.GetCityById(id);
        }

        public async Task<List<StateModel>> GetStateByCountry(int Id)
        {
            return await cityRepository.GetStateByCountry(Id);
        }
    }
}
