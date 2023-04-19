using Azure.Core;
using Hrmanagement.Common;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Xml;

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

        public async Task<ActionResult<Common<List<EmployeeSalaryVm>>>> salaryListOfEmp()
        {
            try
            {  
                    return Ok(new Common<IEnumerable<EmployeeSalaryVm>>
                    {
                        Data = await this.salary.SalaryOfAllEmp(),
                        Success = true,
                        Message = "data display succcessfully",
                    });     
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            



        }
        [HttpPost]
        [Route("AddSalaryDetails")]

        public async Task<ActionResult<Common<int>>> AddSalaryDetails(EmployeeSalaryVm employeeSalaryVm)
        {     
                try
                {
                if(await this.salary.isEmployeeAvailable(employeeSalaryVm.EmpId))
                {
                    return BadRequest("employee is not available!");
                }
                else
                {
                    await salary.save(employeeSalaryVm);
                    return Ok(new Common<IEnumerable<EmployeeSalaryVm>>
                    {
                        Success = true,
                        Message = "data saved succcessfully",
                    });
                }
                
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }     
        }
        [HttpGet]
        [Route("getEmpSalary/{sId}")]
        public async Task<ActionResult<Common<EmployeeSalary>>> getEmpSalary(int sId)
        {
            try
            {
                return Ok(new Common<EmployeeSalary>
                {
                    Data= await salary.GetEmployeeSalary(sId),
                    Success = true,
                    Message = "data display succcessfully",
                });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            //this.salary.GetEmployeeSalary(sId);

        }
        [HttpDelete]
        [Route("deleteEmpSalary/{sId}")]

        public async Task<ActionResult<Common<int>>> DeleteEmpSalary(int sId)
        {
            try
            {
                await this.salary.DeleteEmpSalary(sId);
                return Ok(new Common<IEnumerable<int>>
                {
                Success = true,
                Message = "data delete succcessfully",
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //return this.salary.DeleteEmpSalary(sId);
        }
        [HttpPut]
        [Route("updateEmployeeSalary/{sId}")]

        public async Task<ActionResult<Common<int>>> updateEmployeeSalary(EmployeeSalaryVm employeeSalaryVm, int sId)
        {
            try
            {
                await this.salary.updateSalary(employeeSalaryVm, sId);
                return Ok(new Common<IEnumerable<int>>
                {
                    Success = true,
                    Message = "data updated succcessfully",
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
        

    }
}
