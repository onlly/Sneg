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
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(SnegDbContext context) : base(context)
        {

        }
    }
}
