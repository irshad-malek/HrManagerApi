using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Repository
{
    public class AssigneeRepository : IAssignee
    {
        private readonly HrManagerContext _context;

        public AssigneeRepository(HrManagerContext context)
        {
            _context = context;
        }

        public List<AssigneeVm> GetAssignees()
        {
            return this._context.Assignees.Select(x => new AssigneeVm { 
            AssId = x.AssId,
            JId = x.JId,
            JName=x.JIdNavigation.Emp.FirstName,
            SName=x.SIdNavigation.Emp.FirstName,
            SId = x.SId,
            }).ToList();
        }

        public List<EmployeeVm> GetJuniourAssigns()
        {
            return this._context.Employees.Select(x => new EmployeeVm
            {               
                EmpId = x.EmpId,
                FirstName = x.FirstName,   
            }).ToList();
             
        }

        public List<EmployeeVm> GetSeniorAssigns()
        {
            return this._context.Employees.Select(x => new EmployeeVm
            {
                EmpId = x.EmpId,
                FirstName = x.FirstName
            }).ToList();
        }

        public int jAssignee(int empId)
        {
            JuniourAssign juniourAssign=new  JuniourAssign();
            juniourAssign.EmpId = empId;
            _context.Add(juniourAssign);
            _context.SaveChanges();
            return juniourAssign.JId;
        }

        public int sAssignee(int EmpId)     
        {
            SeniourAssign seniourAssign=new SeniourAssign();
            AprovedLeave aprovedLeave=new AprovedLeave();
            seniourAssign.EmpId = EmpId;
            aprovedLeave.EmpId = EmpId;
            _context.Add(aprovedLeave);
           // _context.SaveChanges();

            _context.Add(seniourAssign);
            _context.SaveChanges();
            return seniourAssign.SId;
        }

        public int save(int jId,int SId)
        {
            Assignee assignee = new Assignee();

            assignee.JId = jId;
            assignee.SId = SId;
            assignee.IsActive = true;
            _context.Add(assignee);
            _context.SaveChanges();

            return assignee.AssId;
        }

        
    }
}
