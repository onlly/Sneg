using System.ComponentModel.DataAnnotations;

namespace Sneg.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
