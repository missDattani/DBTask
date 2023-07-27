using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Model.Config;
using TrainingCoreProject.Model.ViewModels.Company;
using System.Data;
using Dapper;

namespace TrainingCoreProject.Data.DBRepository.Company
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        #region Fields
        public readonly IConfiguration configuration;
        #endregion

        #region Constructor
        public CompanyRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }

     
        #endregion
        public async Task<List<Country>> GetCountries()
        {
            var data = await QueryAsync<Country>("Sp_GetAllCountries", commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        public async Task<List<CompanyList>> GetAllCompanies()
        {
            var data = await QueryAsync<CompanyList>("Sp_GetAllCompanies",commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        public async Task<List<CompanyModel>> GetAllCompanyDetails()
        {
            var data = await QueryAsync<CompanyModel>("Sp_GetCompanyDetails", commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        public async Task<CompanyModel> GetCompanyById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var data = await QueryFirstOrDefaultAsync<CompanyModel>("Sp_GetCompanyById",parameter,commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> AddEditCompanyDetails(CompanyModel company)
        {
            if(company.Id == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", null);
                parameter.Add("@CompanyId", company.CompanyId);
                parameter.Add("@CountryId", company.CountryId);
                parameter.Add("@CityName", company.CityName);
                parameter.Add("@PostalCode", company.PostalCode);
                parameter.Add("@CompanyLogo", company.Image);
                parameter.Add("@Tool", company.Tool);
                var data = await ExecuteAsync<int>("Sp_AddEditCompanyData",parameter,commandType: CommandType.StoredProcedure);
                return data;
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", company.Id);
                parameter.Add("@CompanyId", company.CompanyId);
                parameter.Add("@CountryId", company.CountryId);
                parameter.Add("@CityName", company.CityName);
                parameter.Add("@PostalCode", company.PostalCode);
                parameter.Add("@CompanyLogo", company.Image);
                parameter.Add("@Tool", company.Tool);
                var data = await ExecuteAsync<int>("Sp_AddEditCompanyData", parameter, commandType: CommandType.StoredProcedure);
                return data;
            }
        
        }

        public async Task<int> DeleteCompany(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var data = await ExecuteAsync<int>("Sp_DeleteCompanyData",parameter, commandType: CommandType.StoredProcedure);
            return data;
        }
    }
}
