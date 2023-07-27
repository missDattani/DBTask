using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCoreProject.Model.ViewModels.Company
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public int FilterTotalCount { get; set; }
        public string ImageTitle { get; set; }
        public string Image { get; set; }
        public IFormFile CompanyLogo { get; set; }
        public string Tool { get; set; }
    }

    public class CompanyList
    { 
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }


}
