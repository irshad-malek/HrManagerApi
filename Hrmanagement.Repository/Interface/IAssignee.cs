using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface IAssignee
    {
        int save(int jId, int sId);


        int jAssignee(int empId);

        int sAssignee(int EmpId);

        List<EmployeeVm> GetJuniourAssigns();

        List<EmployeeVm> GetSeniorAssigns();

        List<AssigneeVm> GetAssignees();

    }
}
