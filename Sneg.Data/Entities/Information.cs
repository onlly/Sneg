using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sneg.Data.Entities
{
    public class Information:BaseEntity
    {
        public int UserId { get; set; }
        public string NickName { get; set; }

        public string SummaryContent { get; set; }

        public string FullContent { get; set; }

        public DateTime BirthDate { get; set; }

        //список ФИО в зависимости от выбранного языка
        public IList<FIO> FIOs { get; set; }
        //знания иностранных языков
        public IList<LanguageSkill> Languages { get; set; }

        //public int FIOId { get; set; }
        //[ForeignKey("FIOId")]
        //public FIO FIO { get; set; } 
    }
}
