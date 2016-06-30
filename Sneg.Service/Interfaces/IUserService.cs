using Sneg.Data.Entities;
using Sneg.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Sneg.Service.Interfaces
{
    public interface IUserService : IServiceBase<User>, IUserPasswordStore<UserDto, int>, IUserRoleStore<UserDto, int>
    {
        IEnumerable<UserMinDto> GetUsers();
    }
}
