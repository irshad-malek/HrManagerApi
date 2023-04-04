using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Department
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
