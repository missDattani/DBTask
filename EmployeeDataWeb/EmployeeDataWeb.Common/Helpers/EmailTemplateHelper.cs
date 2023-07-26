using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Common.Helpers
{
    public static class EmailTemplateHelper
    {
        public static string GetEmailTemplateText(string FilePath)
        {
            return File.ReadAllText(FilePath);
        }
    }
}
