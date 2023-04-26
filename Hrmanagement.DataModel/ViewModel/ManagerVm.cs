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

        public int? EmployeeRoleId { get; set; }

        public int? DeptId { get; set; }

        public DateTime? EffectiveFromDate { get; set; }

        public DateTime? EffectiveToDate { get; set; }

        public bool? IsActive { get; set; }

        public int? EmpId { get; set; }

        public string? ManagerName { get; set; }
        public int? EmpIdMgr { get; set; }

    }
}
