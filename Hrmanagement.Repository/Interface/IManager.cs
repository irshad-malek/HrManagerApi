using Hrmanagement.DataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface IManager
    {
        Task<int> SaveManager(ManagerVm managerVm);
        Task<List<ManagerVm>> GetAllManagerList();

    }
}
