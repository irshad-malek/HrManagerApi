﻿using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface IDesignation
    {
        List<DesignationVm> GetDesignations();
    }
}
