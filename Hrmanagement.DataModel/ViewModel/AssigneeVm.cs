using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.DataModel.ViewModel
{
    public class AssigneeVm
    {
        public int AssId { get; set; }

        public int? JId { get; set; }

        public int? SId { get; set; }

        public string? JName { get; set; }
        public string? SName { get; set; }
        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool? IsActive { get; set; }

    }
}
