using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Common.Helpers
{
    public class StoredProcedures
    {
        public const string UserLogin = "Sp_GetLoginData";
        public const string ChangePassword = "Sp_UpdatePassword";
        public const string GetUserByEmail = "Sp_GetUserDataByEmail";
        public const string VerifyOTP = "Sp_VerifyOTP";
        public const string UpdateOTP = "Sp_UpdateOTP";
        public const string UpdateToken = "Sp_UpdateToken";
        public const string ValidateToken = "Sp_ValidateToken";

        public const string AddEditEmployee = "Sp_AddEditEmployeeData";
        public const string AllEmployees = "Sp_GetEmployeeList";
        public const string GetEmployeeById = "Sp_GetEmployeeById";
        public const string DeleteEmployee = "Sp_DeleteEmployee";
        public const string GetEmpDataTable = "Sp_GetEmployeeDataTable";

        public const string GetCompanyList = "Sp_GetCompanyList";

        public const string GetDeptByCompanyId = "Sp_GetDepartmentByCompanyId";

        public const string GetJobRoleByDeptId = "Sp_GetJobRoleBYDeptId";
    }
}
