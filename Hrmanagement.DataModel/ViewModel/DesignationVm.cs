using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class DesignationVm
{
    public int DesgId { get; set; }

    public string? DesName { get; set; }

    //public virtual ICollection<EmployeeVm> Employees { get; } = new List<EmployeeVm>();
}
