using System;
using System.Collections.Generic;

namespace HRmanagement.Models;

public partial class Designation
{
    public int DesgId { get; set; }

    public string? DesName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
