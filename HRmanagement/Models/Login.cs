using System;
using System.Collections.Generic;

namespace HRmanagement.Models;

public partial class Login
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public string? Password { get; set; }

    public virtual Employee? Emp { get; set; }
}
