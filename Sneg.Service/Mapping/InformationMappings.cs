using Sneg.Data.Entities;
using Sneg.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Service.Mapping
{
    public static class InformationMappings
    {
        public static InformationDto ToDto(this Information entityInfo)
        {
            return new InformationDto(entityInfo.Id)
            {
                NickName = entityInfo.NickName,
                SummaryContent = entityInfo.SummaryContent,
                FullContent = entityInfo.FullContent,
                BirthDate = entityInfo.BirthDate,
                UserId = entityInfo.UserId
            };
        }

        public static Information FromDto(this InformationDto dto)
        {
            return new Information
            {
                Id = dto.Id,
                NickName = dto.NickName,
                SummaryContent = dto.SummaryContent,
                FullContent = dto.FullContent,
                BirthDate = dto.BirthDate,
                UserId = dto.UserId
            };
        }
    }
}
