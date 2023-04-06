using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Repository
{
    public class EmployeeRolesRepository : IEmployeeRole
    {
        private readonly HrManagerContext _context;

        public EmployeeRolesRepository(HrManagerContext context)
        {
            _context = context;
        }

        public List<EmployeeRolesVm> GetEmployeeRoles()
        {
            return this._context.EmployeeRoles.Select(x=>new EmployeeRolesVm
            {
                EmployeeRoleId = x.EmployeeRoleId,
                EmployeeRoleName = x.EmployeeRoleName,
                IsActive = x.IsActive
            }).ToList();
        }
    }
}
