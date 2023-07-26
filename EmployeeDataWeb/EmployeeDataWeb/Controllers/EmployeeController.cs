using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Filter;
using EmployeeDataWeb.Model.ViewModels.DataTable;
using EmployeeDataWeb.Model.ViewModels.Employee;
using EmployeeDataWeb.Services.Company;
using EmployeeDataWeb.Services.Department;
using EmployeeDataWeb.Services.Employee;
using EmployeeDataWeb.Services.JobRole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeDataWeb.Controllers
{
    [TypeFilter(typeof(JwtTokenFilter))]
    public class EmployeeController : Controller
    {
        #region Fields
        public IEmployeeServices employeeServices;
        public ICompanyServices companyServices;
        public IDepartmentServices departmentServices;
        public IJobRoleServices jobRoleServices;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeServices employeeServices,ICompanyServices companyServices,IDepartmentServices departmentServices,IJobRoleServices jobRoleServices)
        {
            this.employeeServices = employeeServices;
            this.companyServices = companyServices;
            this.departmentServices = departmentServices;
           this.jobRoleServices = jobRoleServices;
        }
        #endregion

        #region Methods
        public async Task<IActionResult> EmployeeList()
        {
            try
            {
                List<EmployeeModel> empList = await employeeServices.GetAllEmployees();
                return View(empList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var result = await employeeServices.GetEmployeeById(Id);
            return View(result);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModel)
        {
           
                var success = await employeeServices.AddEmployee(employeeModel);
                if(success == (int)EmployeeEnum.Duplicate)
                {
                    TempData["Error"] = "Employee Already Exists";
                    return View();
                }
                else if (success == (int)EmployeeEnum.AddOrCreated)
                {
                    TempData["Message"] = "Employee Added Successfully";
                    return RedirectToAction("EmployeeList");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong";
                    return View();
                }
      
        }

        public async Task<IActionResult> EditEmployee(int Id)
        {
            var data = await employeeServices.GetEmployeeById(Id);
            if(string.IsNullOrEmpty(data.Email) == true)
            {
                TempData["Error"] = "User Not Found";
                return View();
            }
            else
            {
                ViewBag.CompanyList = new SelectList(await companyServices.GetAllCompanies(),"CompanyId","CompanyName");
                ViewBag.DepartmentList = new SelectList(await departmentServices.GetDepartmentByCompanyId(data.CompanyId),"DeptId","DeptName");
                ViewBag.JobList = new SelectList(await jobRoleServices.GetJobRoleByDeptId(data.DeptId), "JobRoleId", "Name");
                return View(data);

            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeModel employee)
        {
            var success = await employeeServices.UpdateEmployee(employee);
            if (success == 1)
            {
                TempData["Message"] = "Employee Updated Successfully";
                return RedirectToAction("EmployeeList");
            }
            else
            {
                TempData["Error"] = "Something Went Wrong";
                return View();
            }
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var success = await employeeServices.DeleteEmployee(id);
                if (success == 0)
                {
                    TempData["Message"] = "Data Deleted Successfully";
                    return RedirectToAction("EmployeeList");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong";
                    return RedirectToAction("EmployeeList");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetEmployees()
        {
            HttpContext context = HttpContext;
            context.Response.ContentType = "text/plain";

            List<string> column = new List<string>();
            column.Add("empURN");
            column.Add("employeeName");
            column.Add("email");
            column.Add("location");
            column.Add("employeeCode");
            column.Add("deptName");
            column.Add("name");
            column.Add("companyName");
           

            Int32 ajaxDraw = Convert.ToInt32(context.Request.Form["draw"]);
            Int32 offSetValue = Convert.ToInt32(context.Request.Form["start"]);
            Int32 pageSize = Convert.ToInt32(context.Request.Form["length"]);

            string? searchBy = context.Request.Form["search[value]"];
            string? sortColumn = context.Request.Form["order[0][column]"];
            sortColumn = column[Convert.ToInt32(sortColumn)];

            string? sortDirection = context.Request.Form["order[0][dir]"];

            List<EmployeeModel> empList = await employeeServices.GetEmployeeDataTable(sortColumn, sortDirection,offSetValue,pageSize,searchBy);
            Int32 recordColumn = 0;

            List<EmployeeDataTableModel> empData = new List<EmployeeDataTableModel>();

            if (!string.IsNullOrEmpty(empList.FirstOrDefault().Email))
            {
                for(int i = 0; i < empList.Count; i++)
                {
                    EmployeeDataTableModel dataTableModel = new EmployeeDataTableModel();
                    dataTableModel.EmpURN = empList[i].EmpURN;
                    dataTableModel.EmployeeName = empList[i].EmployeeName;
                    dataTableModel.Email = empList[i].Email;
                    dataTableModel.Location = empList[i].Location;
                    dataTableModel.EmployeeCode = empList[i].EmployeeCode;
                    dataTableModel.Status = empList[i].Status;
                    dataTableModel.CompanyName = empList[i].CompanyName;
                    dataTableModel.DeptName = empList[i].DeptName;
                    dataTableModel.Name = empList[i].Name;
                    empData.Add(dataTableModel);
                }

                recordColumn = empList.Count() > 0 ? Convert.ToInt32(empList.FirstOrDefault().filterTotalCount) : 0;
            }

            Int32 recordFiltered = recordColumn;

            JqDataTable jqData = new JqDataTable() 
            {
                draw = ajaxDraw,
                recordTotal = recordColumn,
                recordFiltered = recordFiltered,
                data = empData
            };

            return Json(jqData );

        }
        #endregion
    }
}
