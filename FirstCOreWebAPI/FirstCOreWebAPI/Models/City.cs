using System;
using System.Collections.Generic;

namespace FirstCOreWebAPI.Models;

public partial class City
{
    public int CiId { get; set; }

    public string? CityName { get; set; }

    public int? CoId { get; set; }

    public int? StId { get; set; }

    public virtual Country? Co { get; set; }

    public virtual State? St { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
