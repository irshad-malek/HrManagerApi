using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public DateTime? InTime { get; set; }

    public DateTime? OutTime { get; set; }

    public string? Status { get; set; }

    public int? EmpId { get; set; }

    public virtual Employee? Emp { get; set; }
}
