using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class EmployeeTypeVm
{
    public int EmpTypeId { get; set; }

    public string? EmployeeTypes { get; set; }

    //public virtual ICollection<EmployeeVm> Employees { get; } = new List<EmployeeVm>();
}
