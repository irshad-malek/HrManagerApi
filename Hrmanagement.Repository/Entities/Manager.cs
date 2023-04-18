using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? EmployeeRoleId { get; set; }

    public int? DeptId { get; set; }

    public string? MobileNo { get; set; }

    public DateTime? EffectiveFromDate { get; set; }

    public DateTime? EffectiveToDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual EmployeeRole? EmployeeRole { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();
}
