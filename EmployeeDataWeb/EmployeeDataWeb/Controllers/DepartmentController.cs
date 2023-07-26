using EmployeeDataWeb.Model.ViewModels.Department;
using EmployeeDataWeb.Services.Department;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeDataWeb.Controllers
{
    public class DepartmentController : Controller
    {
        #region Fields
        public IDepartmentServices department;
        #endregion

        #region Constructor
        public DepartmentController(IDepartmentServices department)
        {
            this.department = department;
        }
        #endregion
        public async Task<JsonResult> GetDeptByCompanyId(int Id)
        {
            try
            {
                var deptList = await department.GetDepartmentByCompanyId(Id);
                //List<DepartmentModel> DepartmentList = new List<DepartmentModel>();
                //foreach (var item in deptList)
                //{
                //    var data = new DepartmentModel()
                //    {
                //        DeptId = item.DeptId,
                //        DepartmentName = item.DepartmentName,
                //    };
                //    DepartmentList.Add(data);
                //}
                var jsonData = JsonConvert.SerializeObject(deptList);
                return Json(jsonData);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
