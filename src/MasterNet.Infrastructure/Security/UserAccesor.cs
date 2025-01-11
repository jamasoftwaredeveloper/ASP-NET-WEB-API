using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MasterNet.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MasterNet.Infrastructure.Security
{
    public class UserAccesor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccesor(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetEmail()
        {
            return _httpContextAccessor.
          HttpContext!.User.FindFirstValue(ClaimTypes.Email)!;
        }

        public string GetUserName()
        {
            return _httpContextAccessor.
                HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;
        }
    }
}
