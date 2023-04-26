using System;
using System.Collections.Generic;

namespace Hrmanagement.Repository.Entities;

public partial class CompanyVm
{
    public int CompanyId { get; set; }

    public string? Name { get; set; }

    public string? CLocation { get; set; }
}
