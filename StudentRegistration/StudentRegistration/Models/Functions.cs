using StudentRegistration.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    public class Functions
    {
        public static List<StudentModel> Converter(List<Student> users)
        {
            try
            {
                PD326Entities entities = new PD326Entities();
                List<SCountry> countryList = entities.SCountries.ToList();
                List<SState> stateList = entities.SStates.ToList();
                List<SCity> cityList = entities.SCities.ToList();

                List<StudentModel> userModels = new List<StudentModel>();
                foreach (var i in users)
                {
                    userModels.Add(new StudentModel
                    {
                        SId = i.SId,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Address = i.Address,
                        Contact = i.Contact,
                        Email = i.Email,
                        Gender = i.Gender,
                        CountryName = countryList.Find(x => x.CountryId == i.CountryId).CountryName,
                        StateName = stateList.Find(x => x.StateId == i.StateId).StateName,
                        CityName = cityList.Find(x => x.CityId == i.CityId).CityName,
                        CountryId = (int)i.CountryId,
                        StateId = (int)i.StateId,
                        CityId = (int)i.CityId
                    });
                }
                return userModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static List<StudentModel> Converter()
        {
            throw new NotImplementedException();
        }

        public static List<CountryModel> ConvertCountry(List<SCountry> country)
        {
            List<CountryModel> count = new List<CountryModel>();
            foreach (var i in country)
            {
                count.Add(new CountryModel
                {
                    CountryId = i.CountryId,
                    CountryName = i.CountryName
                });
            }
            return count;
        }

        internal static List<CountryModel> ConvertCountry()
        {
            throw new NotImplementedException();
        }

        public static List<StateModel> ConvertState(List<SState> state)
        {
            try
            {
                PD326Entities entities = new PD326Entities();
                List<SCountry> countryList = entities.SCountries.ToList();
                List<StateModel> st = new List<StateModel>();
                foreach (var i in state)
                {
                    st.Add(new StateModel
                    {
                        StateId = i.StateId,
                        StateName = i.StateName,
                        CountryName = countryList.Find(x => x.CountryId == i.CountryId).CountryName,
                        CountryId = (int)i.CountryId
                    });
                }
                return st;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static List<StateModel> ConvertState()
        {
            throw new NotImplementedException();
        }

        public static List<CityModel> ConvertCity(List<SCity> city)
        {
            try
            {
                PD326Entities entities = new PD326Entities();
                List<SCountry> countryList = entities.SCountries.ToList();
                List<SState> stateList = entities.SStates.ToList();
                List<CityModel> ct = new List<CityModel>();
                foreach (var i in city)
                {
                    ct.Add(new CityModel
                    {
                        CityId = i.CityId,
                        CityName = i.CityName,
                        CountryName = countryList.Find(x => x.CountryId == i.CountryId).CountryName,
                        StateName = stateList.Find(x => x.StateId == i.StateId).StateName,
                        CountryId = (int)i.CountryId,
                        StateId = (int)i.StateId
                    });
                }
                return ct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static List<CityModel> ConvertCity()
        {
            throw new NotImplementedException();
        }
    }
}