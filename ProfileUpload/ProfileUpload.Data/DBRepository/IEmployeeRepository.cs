using ProfileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileUpload.Data.DBRepository
{
    public interface IEmployeeRepository
    {
        Task<int> AddEditEmployee(ImageUploadModel imageUpload);

        Task<ImageUploadModel> GetEmployeeById(int id);

        Task<List<ImageUploadModel>> GetAllEmployees();
    }
}
