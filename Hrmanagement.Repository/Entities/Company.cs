using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? Name { get; set; }

    public string? CLocation { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
