﻿using Hrmanagement.DataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface ILogin
    {
        Task<int> createPassword(LoginVm loginVm);
    }
}
