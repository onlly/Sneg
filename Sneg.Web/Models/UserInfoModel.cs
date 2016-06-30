using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sneg.Common.Enums;

namespace Sneg.Web.Models
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RoleEnum> Roles { get; set; } 
    }
}