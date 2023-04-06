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
    public class EmployeeTypeRepository : IEmployeeType
    {
        private readonly HrManagerContext _context;

        public EmployeeTypeRepository(HrManagerContext context)
        {
            _context = context;
        }

        public List<EmployeeTypeVm> GetEmployeeTypes()
        {
            return this._context.EmployeeTypes.Select(x=>new EmployeeTypeVm
            {
                EmpTypeId=x.EmpTypeId,
                EmployeeTypes=x.EmployeeTypes,
            }).ToList();
        }
    }
}
