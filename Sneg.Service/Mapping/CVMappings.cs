using Sneg.Data.Entities;
using Sneg.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Service.Mapping
{
    public static class CVMappings
    {
        public static IQueryable<InformationMinDto> SelectMinDto(this IQueryable<Information> query)
        {
            return query.Select(x => new InformationMinDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Name = x.NickName
            });
        }
        

        public static InformationMinDto ToMinDto(this Information entity)
        {
            return new InformationMinDto
            {
                UserId = entity.UserId,
                Name = entity.NickName
            };
        }
    }
}
