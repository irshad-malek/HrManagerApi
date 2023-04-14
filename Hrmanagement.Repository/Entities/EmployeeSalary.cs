﻿using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class EmployeeSalary
{
    public int SId { get; set; }

    public decimal? BasicsSalary { get; set; }

    public decimal? HouseRent { get; set; }

    public decimal? Medical { get; set; }

    public decimal? GrossSalary { get; set; }

    public decimal? Taxes { get; set; }

    public int EmpId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee? Emp { get; set; }
}
