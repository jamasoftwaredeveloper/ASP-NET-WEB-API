﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNet.Application.Accounts.Login
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
