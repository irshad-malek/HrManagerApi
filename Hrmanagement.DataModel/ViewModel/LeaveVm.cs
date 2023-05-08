using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.DataModel.ViewModel
{
    public class LeaveVm
    {
        public int LeaveId { get; set; }

        public int? LeaveTypeId { get; set; }

        public string? LeaveType { get; set; }
        public DateTime? Fromdate { get; set; }

        public DateTime? ToDate { get; set; }

        public decimal? Contact { get; set; }

        public string? Reason { get; set; }

        public int? ManagerId { get; set; }

        public int? EmpId { get; set; }

        public bool? IsApply { get; set; }

        public bool? IsAccepted { get; set; }

        public string?  FirstName { get; set; }

        public string? SeniorEmpName { get;set; }
        public int? SId { get; set; }
        public bool? IsRejected { get; set; }

    }
}
