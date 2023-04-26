using Hrmanagement.Common;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManager manager;

        public ManagerController(IManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("saveManager")]
        public async Task<ActionResult<Common<int>>> saveManager(ManagerVm managerVm)
        {
            try
            {
               
                    await manager.SaveManager(managerVm);
                    return Ok(new Common<IEnumerable<ManagerVm>>
                    {
                        Success = true,
                        Message = "data saved succcessfully",
                    });
                

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
