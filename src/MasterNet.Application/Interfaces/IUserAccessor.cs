﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNet.Application.Interfaces
{
    public interface IUserAccessor
    {
        string GetUserName();
        string GetEmail();
    }
}
