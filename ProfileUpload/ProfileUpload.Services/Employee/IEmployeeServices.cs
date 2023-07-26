using ProfileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileUpload.Services.Employee
{
    public interface IEmployeeServices
    {
        Task<int> AddEditEmployee(ImageUploadModel imageUpload);

        Task<ImageUploadModel> GetEmployeeById(int id);

        Task<List<ImageUploadModel>> GetAllEmployees();
    }
}
