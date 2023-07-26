using EmployeeDataWeb.Model.ViewModels.JobRole;
using EmployeeDataWeb.Services.JobRole;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeDataWeb.Controllers
{
    public class JobRoleController : Controller
    {
        #region Fields
        public IJobRoleServices JobRoleServices;
        #endregion

        #region Constructor
        public JobRoleController(IJobRoleServices jobRoleServices)
        {
            JobRoleServices = jobRoleServices;
        }
        #endregion
        [HttpGet]
        public async Task<JsonResult> GetJobRoleByDeptId(int Id)
        {
            var jobList = await JobRoleServices.GetJobRoleByDeptId(Id);
             var jsonData = JsonConvert.SerializeObject(jobList);
            return Json(jsonData);
        }
    }
}
