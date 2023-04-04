using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface Idepartment
    {
        List<DepartmentVm> GetDepartments();
        int saveDepartment(DepartmentVm departmentVm);

        bool deleteDepartment(int deptId);

        int Update(DepartmentVm departmentVm, int deptId);

    }
}
