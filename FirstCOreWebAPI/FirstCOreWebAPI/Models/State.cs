using System;
using System.Collections.Generic;

namespace FirstCOreWebAPI.Models;

public partial class State
{
    public int StId { get; set; }

    public string? StateName { get; set; }

    public int? CoId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? Co { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
