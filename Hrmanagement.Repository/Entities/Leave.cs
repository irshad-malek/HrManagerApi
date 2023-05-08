using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Leave
{
    public int LeaveId { get; set; }

    public int? LeaveTypeId { get; set; }

    public DateTime? Fromdate { get; set; }

    public DateTime? ToDate { get; set; }

    public decimal? Contact { get; set; }

    public string? Reason { get; set; }

    public int? ManagerId { get; set; }

    public int? EmpId { get; set; }

    public bool? IsApply { get; set; }

    public bool? IsAccepted { get; set; }

    public int? SId { get; set; }

    public bool? IsRejected { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual LeaveType? LeaveType { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual Session? SIdNavigation { get; set; }
}
