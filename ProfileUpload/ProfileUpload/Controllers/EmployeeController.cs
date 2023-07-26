using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProfileUpload.Models;
using ProfileUpload.Services.Employee;

namespace ProfileUpload.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeServices employeeServices;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public EmployeeController(IEmployeeServices employeeServices, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeServices = employeeServices;
            WebHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> GetEmployeeList()
        {
            List<ImageUploadModel> emp = await employeeServices.GetAllEmployees();
            return View(emp);
        }

        public async Task<IActionResult> AddEditEmployee(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return View();
                }
                else
                {
                    var emp = await employeeServices.GetEmployeeById(Id);
                    return View(emp);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEditEmployee(ImageUploadModel imageUpload)
        {
            try
            {
                string imgFilename = string.Empty;

                if(imageUpload?.ProfileImage != null)
                {
                    string folderPath = Path.Combine(WebHostEnvironment.WebRootPath, "Images");
                    imgFilename = Guid.NewGuid() + "_" + imageUpload?.ProfileImage?.FileName?.Split("\\").LastOrDefault();
                    imageUpload.ProfilePic = imgFilename;
                    string FilePath = Path.Combine(folderPath, imgFilename);
                    imageUpload?.ProfileImage.CopyTo(new FileStream(FilePath, FileMode.Create));
                }

                await employeeServices.AddEditEmployee(imageUpload);
                return RedirectToAction("GetEmployeeList" ,new { id = imageUpload?.Id });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
