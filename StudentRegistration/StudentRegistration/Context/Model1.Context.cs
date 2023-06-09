﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentRegistration.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class PD326Entities : DbContext
    {
        public PD326Entities()
            : base("name=PD326Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SCity> SCities { get; set; }
        public DbSet<SCountry> SCountries { get; set; }
        public DbSet<SState> SStates { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    
        public virtual int sp_DeleteCountry(Nullable<int> countryId)
        {
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCountry", countryIdParameter);
        }
    
        public virtual int sp_DeleteState(Nullable<int> stateId)
        {
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteState", stateIdParameter);
        }
    
        public virtual int sp_DeleteCity(Nullable<int> cityId)
        {
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("CityId", cityId) :
                new ObjectParameter("CityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCity", cityIdParameter);
        }
    }
}
