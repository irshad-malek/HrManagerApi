using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class DepartmentVm
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    //public virtual ICollection<EmployeeVm> Employees { get; } = new List<EmployeeVm>();
}
