using System;
using System.Collections.Generic;

namespace Sneg.Data.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IList<UserRole> UserRoles { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Experience { get; set; }
    }
}
