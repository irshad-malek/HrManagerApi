using Azure.Core;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Hrmanagement.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Repository
{
    public class SalaryRepository : ISalary
    {
        private readonly HrManagerContext _context;

        public SalaryRepository(HrManagerContext context)
        {
            _context = context;
        }

        public async Task<EmployeeSalary> GetEmployeeSalary(int sId)
        {

            return await this._context.EmployeeSalaries.FindAsync(sId);
        }

        public async Task<List<EmployeeSalaryVm>> SalaryOfAllEmp()
        {
            return await this._context.EmployeeSalaries.Select(x => new EmployeeSalaryVm {
                EmpId = x.EmpId,
                FirstName =x.Emp.FirstName,
                BasicsSalary =x.BasicsSalary,
                TaxAmount = x.TaxAmount,
                GrossSalary =x.GrossSalary,
                Medical=x.Medical,
                HouseRent=x.HouseRent,
                SId=x.SId,
                IsActive=x.IsActive
            }).Where(x=>x.IsActive==true).ToListAsync();
        }

        public async Task<int> save(EmployeeSalaryVm employeeSalaryVm)
        {
            EmployeeSalary employeeSalary = new EmployeeSalary();
            if (employeeSalaryVm != null)
            {
                employeeSalary.BasicsSalary = employeeSalaryVm.BasicsSalary;
                employeeSalary.GrossSalary = employeeSalaryVm.GrossSalary;
                employeeSalary.TaxAmount = employeeSalaryVm.TaxAmount;
                employeeSalary.Medical = employeeSalaryVm.Medical;
                employeeSalary.HouseRent = employeeSalaryVm.HouseRent;
                employeeSalary.EmpId = employeeSalaryVm.EmpId;
                employeeSalary.IsActive = employeeSalaryVm.IsActive;
                _context.EmployeeSalaries.Add(employeeSalary);
                await _context.SaveChangesAsync();
            }
            return  employeeSalary.SId;
        }

        public async Task<int> updateSalary(EmployeeSalaryVm employeeSalaryVm, int sId)
        {
            EmployeeSalary empSalary = new EmployeeSalary();
            if (sId > 0)
            {

                empSalary = _context.EmployeeSalaries.FirstOrDefault(t => t.SId == sId);
                empSalary.BasicsSalary = employeeSalaryVm.BasicsSalary;
                empSalary.GrossSalary = employeeSalaryVm.GrossSalary;
                empSalary.TaxAmount = employeeSalaryVm.TaxAmount;
                empSalary.HouseRent = employeeSalaryVm.HouseRent;
                empSalary.EmpId = employeeSalaryVm.EmpId;
                empSalary.IsActive=employeeSalaryVm.IsActive;
                _context.EmployeeSalaries.Update(empSalary);
                await _context.SaveChangesAsync();
            }
            return empSalary.SId;
        }
        public async Task<int> DeleteEmpSalary(int sId)
        {
            bool result = false;
            var emp = _context.EmployeeSalaries.Find(sId);
            EmployeeSalary employeeSalary = new EmployeeSalary();

            if (emp != null)
            {

                employeeSalary = _context.EmployeeSalaries.FirstOrDefault(t => t.SId == sId);
                employeeSalary.IsActive=false; 
                employeeSalary.EmpId=emp.EmpId;
                _context.EmployeeSalaries.Update(employeeSalary);
                await _context.SaveChangesAsync();
            }
            return employeeSalary.SId;

        }

      
    }
}
