using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Service.Dto
{
    public class InformationDto
    {
        public InformationDto()
        {
        }

        public InformationDto(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string SummaryContent { get; set; }

        public string FullContent { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
