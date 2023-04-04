using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class EmployeeType
{
    public int EmpTypeId { get; set; }

    public string? EmployeeTypes { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
