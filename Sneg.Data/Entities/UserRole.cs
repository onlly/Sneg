using Sneg.Common.Enums;

namespace Sneg.Data.Entities
{
    public class UserRole:BaseEntity
    {
        public int UserId { get; set; }
        public RoleEnum Role { get; set; }
    }
}
