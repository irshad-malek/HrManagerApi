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
    public class DesignationRepository : IDesignation
    {
        private readonly HrManagerContext _context;

        public DesignationRepository(HrManagerContext context)
        {
            _context = context;
        }

        public List<DesignationVm> GetDesignations()
        {
           return this._context.Designations.Select(x=>new DesignationVm { 
            DesgId=x.DesgId,
            DesName=x.DesName,
            }).ToList();
        }
    }
}
