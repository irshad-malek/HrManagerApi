using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class EmployeeRole
{
    public int EmployeeRoleId { get; set; }

    public string? EmployeeRoleName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
