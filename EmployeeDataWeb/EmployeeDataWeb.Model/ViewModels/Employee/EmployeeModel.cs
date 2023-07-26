using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Model.ViewModels.Employee
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmpURN { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int DeptId { get; set; }
        [Required]
        public int JobRoleId { get; set; }
        [Required]
        public int EmployeeCode { get; set; }
        [Required]
        public int CompanyId { get; set; }

        public int filterTotalCount { get; set; }
        public string Status { get; set; }
        [Display(Name = "DepartmentName")]
        public string DeptName { get; set; }
        [Display(Name = "JobRoleName")]
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }

    public class EmployeeDataTableModel
    {
        public string EmpURN { get; set; }

        public string EmployeeName { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public int EmployeeCode { get; set; }
        public string Status { get; set; }
        [Display(Name = "DepartmentName")]
        public string DeptName { get; set; }
        [Display(Name = "JobRoleName")]
        public string Name { get; set; }
        public string CompanyName { get; set; }

    }
}