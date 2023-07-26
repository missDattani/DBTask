
using ProfileUpload.Data.DBRepository;
using ProfileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileUpload.Services.Employee
{
    public class EmployeeServices : IEmployeeServices
    {
        private IEmployeeRepository empRepository;

        public EmployeeServices(IEmployeeRepository empRepository)
        {
            this.empRepository = empRepository;
        }
        public async Task<int> AddEditEmployee(ImageUploadModel imageUpload)
        {
            return await empRepository.AddEditEmployee(imageUpload);
        }

        public async Task<List<ImageUploadModel>> GetAllEmployees()
        {
           return await empRepository.GetAllEmployees();
        }

        public async Task<ImageUploadModel> GetEmployeeById(int id)
        {
           return await empRepository.GetEmployeeById(id);
        }
    }
}
