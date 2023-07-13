using System;
using System.Collections.Generic;

namespace FirstCOreWebAPI.Models;

public partial class Student
{
    public int Sid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? TeacherId { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual State? State { get; set; }
}
