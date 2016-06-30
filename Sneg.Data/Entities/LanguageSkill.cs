using Sneg.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sneg.Data.Entities
{
    public class LanguageSkill:BaseEntity
    {
        public int InformationId { get; set; }
        public int LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        public LanguageStatus Status { get; set; }
    }
}
