using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class EmployeeSalary
{
    public int SalaryId { get; set; }

    public decimal? BasicsSalary { get; set; }

    public decimal? HouseRent { get; set; }

    public decimal? Medical { get; set; }

    public decimal? GrossSalary { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public decimal? TaxAmount { get; set; }

    public int? EmpId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee? Emp { get; set; }
}
