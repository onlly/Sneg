using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Data.Entities
{
    public class Education:BaseEntity
    {
        public int InformationId {get;set;}
        public string University { get; set; }
        public string Speciality { get; set; }
        public DateTime GraduationYear { get; set; }
    }
}
