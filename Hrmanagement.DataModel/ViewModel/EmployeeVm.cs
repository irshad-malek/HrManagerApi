using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class EmployeeVm
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

    public int? CId { get; set; }

    public bool? IsActive { get; set; }

    public int? MangerId { get; set; }

    public string? EmployeeTypes { get; set;}

    public string? DesignationName { get; set; }

    public string? DepartmentName { get; set; }

    //public virtual ICollection<AttendanceVm> Attendances { get; } = new List<AttendanceVm>();

    //public virtual DepartmentVm? Dept { get; set; }

    //public virtual DesignationVm? Desg { get; set; }

    //public virtual EmployeeTypeVm? EmpType { get; set; }

    //public virtual ICollection<EmployeeSalaryVm> EmployeeSalaries { get; } = new List<EmployeeSalaryVm>();
}
