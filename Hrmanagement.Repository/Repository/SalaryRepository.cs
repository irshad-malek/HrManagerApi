using Azure.Core;
using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
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

        public EmployeeSalary GetEmployeeSalary(int sId)
        {
            return this._context.EmployeeSalaries.Find(sId);
        }

        public List<EmployeeSalaryVm> SalaryOfAllEmp()
        {
            return this._context.EmployeeSalaries.Select(x => new EmployeeSalaryVm { 
                EmpId= x.EmpId,
                firstName=x.Emp.FirstName,
                BasicsSalary =x.BasicsSalary,
                Taxes=x.Taxes,
                GrossSalary=x.GrossSalary,
                Medical=x.Medical,
                HouseRent=x.HouseRent,
                SId=x.SId,
                IsActive=x.IsActive
            }).Where(x=>x.IsActive==true).ToList();
        }

        public int save(EmployeeSalaryVm employeeSalaryVm)
        {
            EmployeeSalary employeeSalary = new EmployeeSalary();
            employeeSalary.BasicsSalary=employeeSalaryVm.BasicsSalary;
            employeeSalary.GrossSalary=employeeSalaryVm.GrossSalary;
            employeeSalary.Taxes=employeeSalaryVm.Taxes;
            employeeSalary.Medical=employeeSalaryVm.Medical;
            employeeSalary.HouseRent= employeeSalaryVm.HouseRent;
            employeeSalary.EmpId= employeeSalaryVm.EmpId;
            employeeSalary.IsActive=employeeSalaryVm.IsActive;
            _context.Add(employeeSalary);
            _context.SaveChanges();
            return employeeSalary.SId;
        }

        public int updateSalary(EmployeeSalaryVm employeeSalaryVm, int sId)
        {
            EmployeeSalary empSalary = new EmployeeSalary();
            if (sId > 0)
            {

                empSalary = _context.EmployeeSalaries.FirstOrDefault(t => t.SId == sId);
                empSalary.BasicsSalary = employeeSalaryVm.BasicsSalary;
                empSalary.GrossSalary = employeeSalaryVm.GrossSalary;
                empSalary.Taxes = employeeSalaryVm.Taxes;
                empSalary.HouseRent = employeeSalaryVm.HouseRent;
                empSalary.EmpId = employeeSalaryVm.EmpId;
                empSalary.IsActive=true;
                _context.EmployeeSalaries.Update(empSalary);
                _context.SaveChanges();
            }
            return empSalary.SId;
        }
        public int DeleteEmpSalary(int sId)
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
                _context.SaveChanges();
            }
            return employeeSalary.SId;

        }
    }
}
