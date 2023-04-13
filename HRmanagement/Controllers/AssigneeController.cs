using Azure.Core;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssigneeController : ControllerBase
    {
        private readonly IAssignee assignee;

        public AssigneeController(IAssignee assignee)
        {
            this.assignee = assignee;
        }
        
        [HttpPost]
        [Route("addAssignee/{eId}/{EmpId}")]
        public async Task<int> addAssignee(int eId, int EmpId)
        {
            int data=await JuniourAssign(eId);
            int data1 = await SeniourAssign(EmpId);
            return this.assignee.save(data, data1);
        }
        [HttpPost]
        [Route("addjAssignee")]
        public async Task<int> JuniourAssign(int eId)
        {
            return this.assignee.jAssignee(eId);
        }
        [HttpPost]
        [Route("addsAssignee")]
        public async Task<int> SeniourAssign(int EmpId)
        {
            return this.assignee.sAssignee(EmpId);
        }
        [HttpGet]
        [Route("juniourAssign")]
        public List<EmployeeVm> GetJunioursAssign()
        {
            return this.assignee.GetJuniourAssigns();
        }
        [HttpGet]
        [Route("seniourAssign")]
        public List<EmployeeVm> GetSeniorAssign()
        {
            return this.assignee.GetSeniorAssigns();
        }
        [HttpGet]
        [Route("AssignList")]

        public List<AssigneeVm> AssignList()
        {
            return this.assignee.GetAssignees();
        }
    }
}
