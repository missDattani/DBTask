using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Model.ViewModels
{
    public class DataTableModel
    {
        public string sortColumn { get; set; }
        public string sortOrder { get; set; }
        public int offSetVal { get; set; }
        public int pageSize { get; set; }
        public string searchText { get; set; }
    }

    public class DatatableResponseModel 
    {
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public List<CountryDataModel> data { get; set; }
    }

}
