using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignation iDesignation;
        public DesignationController(IDesignation iDesignation)
        {
            this.iDesignation = iDesignation;
        }

        [HttpGet]
        [Route("getDesignation")]
        public List<DesignationVm> getDesignation()
        {
          return this.iDesignation.GetDesignations();
        }
    }
}
