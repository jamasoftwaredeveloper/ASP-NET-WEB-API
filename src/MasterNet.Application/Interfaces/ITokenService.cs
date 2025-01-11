using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterNet.Persistence.Models;

namespace MasterNet.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);


    }
}
