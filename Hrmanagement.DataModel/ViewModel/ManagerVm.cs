using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.DataModel.ViewModel
{
    public class ManagerVm
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

    }
}
