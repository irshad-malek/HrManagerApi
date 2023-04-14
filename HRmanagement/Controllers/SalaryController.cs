using Azure.Core;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalary salary;

        public SalaryController(ISalary salary)
        {
            this.salary = salary;
        }

        [HttpGet]
        [Route("salaryListOfEmp")]

        public List<EmployeeSalaryVm> salaryListOfEmp()
        {
            return this.salary.SalaryOfAllEmp();
        }
        [HttpPost]
        [Route("AddSalaryDetails")]

        public int AddSalaryDetails(EmployeeSalaryVm employeeSalaryVm)
        {
            return this.salary.save(employeeSalaryVm);
        }
        [HttpGet]
        [Route("getEmpSalary/{sId}")]
        public EmployeeSalary getEmpSalary(int sId)
        {
            return this.salary.GetEmployeeSalary(sId);
        }
        [HttpDelete]
        [Route("deleteEmpSalary/{sId}")]

        public int DeleteEmpSalary(int sId)
        {
            return this.salary.DeleteEmpSalary(sId);
        }
        [HttpPut]
        [Route("updateEmployeeSalary/{sId}")]

        public int updateEmployeeSalary(EmployeeSalaryVm employeeSalaryVm, int sId)
        {
            return this.salary.updateSalary(employeeSalaryVm, sId);
        }
        

    }
}
