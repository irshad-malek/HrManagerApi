using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class AprovedLeave
{
    public int AId { get; set; }

    public int? EmpId { get; set; }

    public bool? IsApproved { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
