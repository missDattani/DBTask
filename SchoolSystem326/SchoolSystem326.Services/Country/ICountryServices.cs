﻿using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.Country
{
    public interface ICountryServices
    {
        Task<int> AddEditCountry(CountryModel countryModel);

        Task<CountryModel> GetCountryById(int id);

        Task<List<CountryModel>> GetAllCountry();
    }
}
