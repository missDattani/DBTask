using System;
using System.Collections.Generic;

namespace FirstCOreWebAPI.Models;

public partial class User1
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PassWord { get; set; }
}
