using System;
using System.Collections.Generic;

namespace HRmanagement.Models;

public partial class Session
{
    public int SessionId { get; set; }

    public string? Sessions { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
