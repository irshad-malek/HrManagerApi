using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface ISalary
    {
        int save(EmployeeSalaryVm employeeSalaryVm);

        List<EmployeeSalaryVm> SalaryOfAllEmp();

        int updateSalary(EmployeeSalaryVm employeeSalaryVm,int sId);

        EmployeeSalary GetEmployeeSalary(int sId);

        public int DeleteEmpSalary(int sId);

    }
}
