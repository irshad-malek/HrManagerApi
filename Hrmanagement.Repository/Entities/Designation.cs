using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Designation
{
    public int DesgId { get; set; }

    public string? DesName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
