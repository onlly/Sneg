using Sneg.Common.Enums;
using Sneg.Data.Entities;
using System.Collections.Generic;

namespace Sneg.Data.Repositories.Interfaces
{
    public interface IUserRoleRepository:IRepository<UserRole>
    {
        UserRole GetByUserIdAndRole(int userId, RoleEnum role);
        IEnumerable<UserRole> GetByUserId(int userId);
        bool HasRole(int userId, RoleEnum role);
    }
}
