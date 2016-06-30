using Sneg.Common.Enums;
using Sneg.Data.Context;
using Sneg.Data.Entities;
using Sneg.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Data.Repositories.Implementation
{
    public class UserRoleRepository:RepositoryBase<UserRole>,IUserRoleRepository
    {
        public UserRoleRepository(SnegDbContext context) : base(context)
        {

        }

        public UserRole GetByUserIdAndRole(int userId, RoleEnum role)
        {
            return Query().SingleOrDefault(x => x.UserId == userId && x.Role == role);
        }
        public IEnumerable<UserRole> GetByUserId(int userId)
        {
            return Query().Where(x => x.UserId == userId).ToList();
        }
        public bool HasRole(int userId, RoleEnum role)
        {
            return Query().Any(x => x.UserId == userId && x.Role == role);
        }
    }
}
