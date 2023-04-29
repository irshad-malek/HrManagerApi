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
    public class LoginRepository : ILogin
    {
        private readonly HrManagerContext _context;

        public LoginRepository(HrManagerContext context)
        {
            _context = context;
        }

        public async Task<int> createPassword(LoginVm loginVm)
        {
            bool result = false;
            bool isExist = false;
            Login login = new();
            result=_context.Employees.Where(x => x.EmailId == loginVm.EmailId).Any();
            if (loginVm != null)
            {
                if (result)
                {
                    var data=_context.Employees.Where(x => x.EmailId == loginVm.EmailId).Select(x=>x.EmpId).First();
                    isExist = _context.Logins.Where(x => x.EmpId == data).Select(x => x.Id).Any();

                    if (isExist)
                    {
                        var data1 = _context.Logins.Where(x => x.EmpId == data).Select(x => x.Id).First();

                        login = _context.Logins.FirstOrDefault(x=>x.Id==data1);
                        //login.EmpId = _context.Employees.Where(x => x.EmailId == loginVm.EmailId).Select(x => x.EmpId).FirstOrDefault();
                        login.Password = loginVm.Password;
                       _context.Update(login);
                       await _context.SaveChangesAsync();
                    }
                    else
                    {
                        login.EmpId = _context.Employees.Where(x => x.EmailId == loginVm.EmailId).Select(x => x.EmpId).FirstOrDefault();
                        login.Password = loginVm.Password;
                        await this._context.AddAsync(login);
                        this._context.SaveChangesAsync();
                    }           
                }
            }
            return login.Id;
        }
    }
}
