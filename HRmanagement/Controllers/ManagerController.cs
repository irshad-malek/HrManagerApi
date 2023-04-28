using Hrmanagement.Common;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;

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
        [HttpGet]
        [Route("getAllManager")]

        public async Task<ActionResult<Common<List<ManagerVm>>>> getAllManager()
        {
            try
            {

                return Ok(new Common<IEnumerable<ManagerVm>>
                {
                    Data = await manager.GetAllManagerList(),
                    Success = true,
                    Message = "data display successfully"
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet]
        [Route("getManagerById/{id}")]
        public Manager getManagerById(int id)
        {
            return manager.GetManagerById(id);
        }
        [HttpPut]
        [Route("updateManagers/{id}")]

        public async Task<ActionResult<Common<int>>> updateManagers(int id,ManagerVm managerVm)
        {
            try
            {

                await manager.updateMangers(id,managerVm);
                return Ok(new Common<IEnumerable<ManagerVm>>
                {
                    Success = true,
                    Message = "data update succcessfully",
                });


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
