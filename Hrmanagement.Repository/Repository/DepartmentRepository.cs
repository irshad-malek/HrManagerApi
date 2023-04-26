using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Hrmanagement.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hrmanagement.Repository.Repository
{
    public class DepartmentRepository : Idepartment
    {
        private HrManagerContext hrManagerContext;

        public DepartmentRepository(HrManagerContext hrManagerContext)
        {
            this.hrManagerContext = hrManagerContext;
        }

        public List<DepartmentVm> GetDepartments()
        {
         return this.hrManagerContext.Departments.Select(x=>new DepartmentVm
            {
                DeptId=x.DeptId,
                DeptName=x.DeptName,
            }).ToList();
        }

        public int saveDepartment(DepartmentVm departmentVm)
        {
            Department dept = new Department();
            dept.DeptName = departmentVm.DeptName;
            hrManagerContext.Departments.Add(dept);
            hrManagerContext.SaveChanges();
            return dept.DeptId;
        }

        public bool deleteDepartment(int deptId) {
            var result = false;
            var dept = hrManagerContext.Departments.Find(deptId);
            if (dept != null)
            {
                hrManagerContext.Remove(dept);
                hrManagerContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }

        public int Update(DepartmentVm departmentVm, int deptId)
        {
            Department dept = new Department();
            if (deptId > 0)
            {
                dept = hrManagerContext.Departments.FirstOrDefault(t => t.DeptId == deptId);
                dept.DeptName = departmentVm.DeptName;
               
                hrManagerContext.Departments.Update(dept);
                hrManagerContext.SaveChanges();
            }
            return dept.DeptId;

        }


    }
}
