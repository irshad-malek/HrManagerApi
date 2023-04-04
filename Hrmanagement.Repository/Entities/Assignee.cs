using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Assignee
{
    public int AssId { get; set; }

    public int? JId { get; set; }

    public int? SId { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual JuniourAssign? JIdNavigation { get; set; }

    public virtual SeniourAssign? SIdNavigation { get; set; }
}
