using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProfileUpload.Common.Helper;
using ProfileUpload.Model.Config;
using ProfileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProfileUpload.Data.DBRepository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig,configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddEditEmployee(ImageUploadModel imageUpload)
        {
            if(imageUpload.Id == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", null);
                parameter.Add("@Name", imageUpload.Name);
                parameter.Add("@Email", imageUpload.Email);
                parameter.Add("@Department", imageUpload.Department);
                parameter.Add("@ProfilePic", imageUpload.ProfilePic);
                return await ExecuteAsync<int>(StoredProcedures.InsertEmployee, parameter,commandType:CommandType.StoredProcedure);
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", imageUpload.Id);
                parameter.Add("@Name", imageUpload.Name);
                parameter.Add("@Email", imageUpload.Email);
                parameter.Add("@Department", imageUpload.Department);
                parameter.Add("@ProfilePic", imageUpload.ProfilePic);
                return await ExecuteAsync<int>(StoredProcedures.InsertEmployee, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<ImageUploadModel>> GetAllEmployees()
        {
           var emp = await QueryAsync<ImageUploadModel>(StoredProcedures.GetAllEmployee, commandType: CommandType.StoredProcedure);
            return emp.ToList();
        }

        public async Task<ImageUploadModel> GetEmployeeById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            return await QueryFirstOrDefaultAsync<ImageUploadModel>(StoredProcedures.GetEmpById, parameter,commandType : CommandType.StoredProcedure);
        }
    }
}
