using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface IEmployee
    {
        List<EmployeeVm> GetEmployees();

        int Save(EmployeeVm employeeVm);
        bool Delete(int EmpId);

        int Update(EmployeeVm employeeVm,int EmpId);

        Employee GetEmployeeById(int empId);

        List<CompanyVm> GetCompanyList();

    }
}
