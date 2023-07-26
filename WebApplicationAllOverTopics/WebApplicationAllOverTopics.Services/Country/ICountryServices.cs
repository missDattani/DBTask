using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Services.Country
{
    public interface ICountryServices
    {
        Task<List<CountryModel>> GetCountries();
    }
}
