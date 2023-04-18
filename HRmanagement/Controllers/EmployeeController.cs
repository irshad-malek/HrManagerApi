using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee Iemployee;

        public EmployeeController(IEmployee iemployee)
        {
            Iemployee = iemployee;
        }

        [HttpGet]
        [Route("getEmployees")]
        public List<EmployeeVm> GetEmployees()
        {
            return this.Iemployee.GetEmployees();
        }

        [HttpPost]
        [Route("employeeSave")]

        public int employeeSave(EmployeeVm employeeVm)
        {
            return this.Iemployee.Save(employeeVm);
        }

        [HttpDelete]
        [Route("emloyeeDelete/{EmpId}")]

        public bool deleteEmployee(int EmpId)
        {
            return this.Iemployee.Delete(EmpId);   
        }

        [HttpPut]
        [Route("updateEmployee/{EmpId}")]

        public int updateEmployee(EmployeeVm employeeVm,int EmpId)
        {
            return this.Iemployee.Update(employeeVm, EmpId);
        }

        [HttpGet]
        [Route("GetCompanyList")]

        public List<CompanyVm> GetCompanyList()
        {
            return this.Iemployee.GetCompanyList();
        }
        [HttpGet]
        [Route("getEmployeeById/{empId}")]

        public Employee GetEmployeeById(int empId)
        {
            return this.Iemployee.GetEmployeeById(empId);
        }
    }
}
