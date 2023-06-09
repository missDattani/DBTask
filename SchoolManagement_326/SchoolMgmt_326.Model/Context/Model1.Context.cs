﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolMgmt_326.Model.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Pooja_SchoolMgmt_326Entities2 : DbContext
    {
        public Pooja_SchoolMgmt_326Entities2()
            : base("name=Pooja_SchoolMgmt_326Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int sp_AddEditCities(Nullable<int> cityId, string cityName, Nullable<int> stateId, Nullable<int> countryId)
        {
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("CityId", cityId) :
                new ObjectParameter("CityId", typeof(int));
    
            var cityNameParameter = cityName != null ?
                new ObjectParameter("CityName", cityName) :
                new ObjectParameter("CityName", typeof(string));
    
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddEditCities", cityIdParameter, cityNameParameter, stateIdParameter, countryIdParameter);
        }
    
        public virtual int sp_AddEditCountry(Nullable<int> countryId, string countryName)
        {
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            var countryNameParameter = countryName != null ?
                new ObjectParameter("CountryName", countryName) :
                new ObjectParameter("CountryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddEditCountry", countryIdParameter, countryNameParameter);
        }
    
        public virtual int sp_AddEditState(Nullable<int> stateId, string stateName, Nullable<int> countryId)
        {
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            var stateNameParameter = stateName != null ?
                new ObjectParameter("StateName", stateName) :
                new ObjectParameter("StateName", typeof(string));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddEditState", stateIdParameter, stateNameParameter, countryIdParameter);
        }
    
        public virtual int sp_AddEditStudent(Nullable<int> stdId, string firstName, string lastName, string address, string mobile, string email, string gender, Nullable<int> teacherId, Nullable<int> countryId, Nullable<int> stateId, Nullable<int> cityId)
        {
            var stdIdParameter = stdId.HasValue ?
                new ObjectParameter("StdId", stdId) :
                new ObjectParameter("StdId", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var teacherIdParameter = teacherId.HasValue ?
                new ObjectParameter("TeacherId", teacherId) :
                new ObjectParameter("TeacherId", typeof(int));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("CityId", cityId) :
                new ObjectParameter("CityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddEditStudent", stdIdParameter, firstNameParameter, lastNameParameter, addressParameter, mobileParameter, emailParameter, genderParameter, teacherIdParameter, countryIdParameter, stateIdParameter, cityIdParameter);
        }
    
        public virtual int sp_AddEditSubject(Nullable<int> subId, string subjectName)
        {
            var subIdParameter = subId.HasValue ?
                new ObjectParameter("SubId", subId) :
                new ObjectParameter("SubId", typeof(int));
    
            var subjectNameParameter = subjectName != null ?
                new ObjectParameter("SubjectName", subjectName) :
                new ObjectParameter("SubjectName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddEditSubject", subIdParameter, subjectNameParameter);
        }
    
        public virtual ObjectResult<SP_GetTeacherDetails_Result> SP_GetTeacherDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetTeacherDetails_Result>("SP_GetTeacherDetails");
        }
    
        public virtual ObjectResult<SP_GetStudentDetails_Result> SP_GetStudentDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetStudentDetails_Result>("SP_GetStudentDetails");
        }
    
        public virtual ObjectResult<SP_GetStudentDetails1_Result> SP_GetStudentDetails1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetStudentDetails1_Result>("SP_GetStudentDetails1");
        }
    
        public virtual ObjectResult<SP_GetTeacherDetails1_Result> SP_GetTeacherDetails1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetTeacherDetails1_Result>("SP_GetTeacherDetails1");
        }
    }
}
