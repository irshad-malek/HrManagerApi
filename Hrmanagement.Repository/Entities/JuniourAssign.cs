using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class JuniourAssign
{
    public int JId { get; set; }

    public int? EmpId { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Assignee> Assignees { get; } = new List<Assignee>();

    public virtual Employee? Emp { get; set; }
}
