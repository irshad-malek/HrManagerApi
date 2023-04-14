using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Session
{
    public int SId { get; set; }

    public string? Sessions { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
