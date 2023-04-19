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
        // int save(EmployeeSalaryVm employeeSalaryVm);
        Task<int> save(EmployeeSalaryVm employeeSalaryVm);
        Task<List<EmployeeSalaryVm>> SalaryOfAllEmp();

        //int updateSalary(EmployeeSalaryVm employeeSalaryVm,int sId);
        Task<int> updateSalary(EmployeeSalaryVm employeeSalaryVm, int sId);

        //Task<EmployeeSalary> GetEmployeeSalary(int sId);
        Task<EmployeeSalary> GetEmployeeSalary(int sId);
        Task<int> DeleteEmpSalary(int sId);

        Task<bool> isEmployeeAvailable(int? EmpId);

        //public int DeleteEmpSalary(int sId);

    }
}
