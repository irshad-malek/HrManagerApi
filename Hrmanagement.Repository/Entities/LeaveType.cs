using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class LeaveType
{
    public int LeaveTypeId { get; set; }

    public string? LeaveTypes { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
