using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class LeaveType
{
    public int LtId { get; set; }

    public string? LeaveType1 { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
