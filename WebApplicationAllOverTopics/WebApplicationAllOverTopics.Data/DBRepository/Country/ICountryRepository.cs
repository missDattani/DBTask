using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Data.DBRepository.Country
{
    public interface ICountryRepository
    {
        Task<List<CountryModel>> GetCountries();
    }
}
