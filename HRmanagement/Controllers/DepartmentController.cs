using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly Idepartment idepartment;

        public DepartmentController(Idepartment idepartment)
        {
            this.idepartment = idepartment;
        }

        [HttpGet]
        [Route("getDepartment")]
        public List<DepartmentVm> getDepartment()
        {
            return this.idepartment.GetDepartments();
        }

        [HttpPost]
        [Route("saveDepartment")]

        public int saveDepartment(DepartmentVm departmentVm)
        {
            return this.idepartment.saveDepartment(departmentVm);
        }

        [HttpDelete]
        [Route("deleteDepartment/{deptId}")]

        public bool deleteDepartment(int deptId)
        {
            return this.idepartment.deleteDepartment(deptId);
        }

        [HttpPut]
        [Route("updateDepartment/deptId")]

        public int updateDepartment(DepartmentVm departmentVm,int deptId)
        {
            return this.idepartment.Update(departmentVm, deptId);
        }

    }
}
