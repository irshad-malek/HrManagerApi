using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public decimal? MobileNo { get; set; }

    public string? EmailId { get; set; }

    public string? Address { get; set; }

    public int? DeptId { get; set; }

    public int? EmpTypeId { get; set; }

    public int? DesgId { get; set; }

    public int? EmployeeRoleId { get; set; }

    public int? CompanyId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual Company? Company { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Designation? Desg { get; set; }

    public virtual EmployeeType? EmpType { get; set; }

    public virtual EmployeeRole? EmployeeRole { get; set; }

    public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; } = new List<EmployeeSalary>();

    public virtual ICollection<Leave> Leaves { get; } = new List<Leave>();

    public virtual ICollection<Login> Logins { get; } = new List<Login>();

    public virtual ICollection<Manager> ManagerEmpIdMgrNavigations { get; } = new List<Manager>();

    public virtual ICollection<Manager> ManagerEmps { get; } = new List<Manager>();
}
