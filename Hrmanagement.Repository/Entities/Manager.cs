using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Manager
{
    public int ManagerId { get; set; }

    public int? EmployeeRoleId { get; set; }

    public int? DeptId { get; set; }

    public DateTime? EffectiveFromDate { get; set; }

    public DateTime? EffectiveToDate { get; set; }

    public bool? IsActive { get; set; }

    public int? EmpId { get; set; }

    public int? EmpIdMgr { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual Employee? EmpIdMgrNavigation { get; set; }

    public virtual EmployeeRole? EmployeeRole { get; set; }

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
