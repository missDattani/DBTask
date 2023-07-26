using EmployeeDataWeb.Model.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Model.ViewModels.DataTable
{
    public class DataTable
    { 
        public string sortColumn { get; set; }
        public string sortOrder { get; set;}
        public int offSetValue { get; set; }
        public int pageSize { get; set; }
        public string searchText { get; set; }
    }

    public class JqDataTable
    {
        public int draw { get; set; }
        public int recordFiltered { get; set; }
        public int recordTotal { get; set; }
        public List<EmployeeDataTableModel> data { get; set; }
    }
}
