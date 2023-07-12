using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Common.Helper
{
    public class StoredProcedures
    {
        #region User
        public const string UserLogin = "Sp_UserLogin";
        public const string RegisterUser = "Sp_RegisterUser";
        public const string GetUserById = "Sp_GetUserById";
        public const string GetUsers = "Sp_GetUsers";
        #endregion

        #region Country
        public const string GetAllCountries = "Sp_GetCountries";
        public const string InsertCountry = "Sp_AddEditCountry";
        public const string GetCountryById = "Sp_GetCountryById";
        #endregion

        #region State
        public const string GetAllStates = "Sp_GetStates";
        public const string InsertState = "Sp_AddEditStates";
        public const string GetStateById = "Sp_GetStateById";
        #endregion

        #region City
        public const string GetAllCities = "Sp_GetCities";
        public const string InsertCity = "Sp_AddEditCity";
        public const string GetCityById = "Sp_GetCityById";
        public const string GetStateByCountryid = "Sp_GetStateByCountryId";
        public const string GetCityByStateId = "Sp_GetCityByStateId";
        #endregion
    }
}
