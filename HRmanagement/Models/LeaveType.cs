using System;
using System.Collections.Generic;

namespace HRmanagement.Models;

public partial class LeaveType
{
    public int LeaveTypeId { get; set; }

    public string? LeaveTypes { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
