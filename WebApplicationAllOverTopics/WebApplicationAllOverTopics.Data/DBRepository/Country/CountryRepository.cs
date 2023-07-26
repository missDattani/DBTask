using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Common.Helpers;
using WebApplicationAllOverTopics.Model.Config;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Data.DBRepository.Country
{
    public class CountryRepository :BaseRepository, ICountryRepository
    {
        #region Fields
        private readonly IConfiguration configuration;
        #endregion

        #region Constructor
        public CountryRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        public async Task<List<CountryModel>> GetCountries()
        {
            var data = await QueryAsync<CountryModel>(StoredProcedures.AllCountries, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
