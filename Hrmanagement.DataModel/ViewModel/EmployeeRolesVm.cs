using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.DataModel.ViewModel
{
    public class EmployeeRolesVm
    {
        public int EmployeeRoleId { get; set; }

        public string? EmployeeRoleName { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool? IsActive { get; set; }
    }
}
