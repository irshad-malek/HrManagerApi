using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class AttendanceVm
{
    public int AttendanceId { get; set; }

    public DateTime? InTime { get; set; }

    public DateTime? OutTime { get; set; }

    public string? Status { get; set; }

    public int? EmpId { get; set; }

    public virtual EmployeeVm? Emp { get; set; }
}
