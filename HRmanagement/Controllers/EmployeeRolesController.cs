using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRolesController : ControllerBase
    {
        private readonly IEmployeeRole employeeRole;

        public EmployeeRolesController(IEmployeeRole employeeRole)
        {
            this.employeeRole = employeeRole;
        }

        [HttpGet]
        [Route("getEmployeeRoles")]

        public List<EmployeeRolesVm> getEmployeeRoles()
        {
            return this.employeeRole.GetEmployeeRoles();
        }
    }
}
