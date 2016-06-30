using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Service.Models
{
    public class UserDto : IUser<int>
    {
         public UserDto()
        {
        }

        public UserDto(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
