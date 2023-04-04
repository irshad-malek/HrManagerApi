using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private HrManagerContext hrManagerContext;

        public EmployeeRepository(HrManagerContext hrManagerContext)
        {
            this.hrManagerContext = hrManagerContext;
        }

        public List<EmployeeVm> GetEmployees()
        {
            return this.hrManagerContext.Employees.Include(x=>x.Desg).Include(x=>x.Dept).Include(x=>x.EmpType).Select(x=>new EmployeeVm
            {
                EmpId = x.EmpId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                MobileNo = x.MobileNo,
                EmailId=x.EmailId,
                Address = x.Address,
                deptName=x.Dept.DeptName,
                desName=x.Desg.DesName,
                employeeTypes=x.EmpType.EmployeeTypes



            }).ToList();
        }

        public int Save(EmployeeVm employeeVm)
        {
            Employee emp=new Employee();
            emp.FirstName = employeeVm.FirstName;
            emp.LastName = employeeVm.LastName;
            emp.Gender = employeeVm.Gender;
            emp.MobileNo = employeeVm.MobileNo;
            emp.EmailId = employeeVm.EmailId;
            emp.Address= employeeVm.Address;
            emp.DeptId = employeeVm.DeptId;
            emp.DesgId = employeeVm.DesgId;
            emp.EmpTypeId = employeeVm.EmpTypeId;
            emp.CId = employeeVm.CId;
            hrManagerContext.Employees.Add(emp);
            hrManagerContext.SaveChanges();
            return emp.EmpId;
        }
        public bool Delete(int EmpId)
        {
            bool result = false;
            var emp = hrManagerContext.Employees.Find(EmpId);
            if (emp != null)
            {
                hrManagerContext.Remove(emp);
                hrManagerContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public int Update(EmployeeVm employeeVm, int EmpId)
        {
            Employee emp = new Employee();
            if (EmpId > 0)
            {
                emp = hrManagerContext.Employees.FirstOrDefault(t => t.EmpId == EmpId);
                emp.FirstName=employeeVm.FirstName;
                emp.LastName=employeeVm.LastName;
                emp.Address = employeeVm.Address;
                emp.MobileNo = employeeVm.MobileNo;
                emp.EmailId = employeeVm.EmailId;
                emp.DeptId = employeeVm.DeptId;
                emp.DesgId = employeeVm.DesgId;
                emp.Gender = employeeVm.Gender;
                emp.EmpTypeId = employeeVm.EmpTypeId;
                hrManagerContext.Employees.Update(emp);
                hrManagerContext.SaveChanges();
            }
            return emp.EmpId;

        }

    }
}
