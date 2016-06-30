using Sneg.Data.Entities;
using Sneg.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Service.Mapping
{
    public static class UserMappings
    {
        public static UserDto ToDto(this User entityUser)
        {
            return new UserDto(entityUser.Id)
            {
                Password = entityUser.Password,
                UserName = entityUser.UserName,
                LastName = entityUser.LastName,
                FirstName = entityUser.FirstName,
                BirthDate = entityUser.BirthDate
            };
        }

        public static User FromDto(this UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Password = dto.Password,
                UserName = dto.UserName,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                BirthDate = dto.BirthDate
            };
        }
        public static IQueryable<UserMinDto> SelectMinDto(this IQueryable<User> query)
        {
            return query.Select(x => new UserMinDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                });
        }
    }
}
