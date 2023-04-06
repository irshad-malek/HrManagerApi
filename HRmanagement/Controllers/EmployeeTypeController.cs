using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeType employeeType;

        public EmployeeTypeController(IEmployeeType employeeType)
        {
            this.employeeType = employeeType;
        }

        [HttpGet]
        [Route("GetEmployeeTypes")]
        public List<EmployeeTypeVm> GetEmployeeTypes()
        {
            return this.employeeType.GetEmployeeTypes();
        }
    }
}
