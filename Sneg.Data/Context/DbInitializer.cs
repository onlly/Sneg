using Sneg.Common.Enums;
using Sneg.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Data.Context
{
    public class DbInitializer : DbMigrationsConfiguration<SnegDbContext>
    {
        public DbInitializer()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SnegDbContext context)
        {
            context.Users.AddOrUpdate(x => x.Id, new User
            {
                Id = 1,
                BirthDate = DateTime.Now,
                FirstName = "qqq",
                LastName = "qqq",
                Experience = 1,
                Password = "ALzShjmY2shrC9kizDGATkZCDDbo+Lk+2y9lkt2Gi/5FVjE00umWf0/VcGQW4wsxKA==",
                UserName = "qqq"
            });

            context.UserRoles.AddOrUpdate(x => new { x.UserId, x.Role }, new UserRole
            {
                UserId = 1,
                Role = RoleEnum.Administrator
            });

            context.Informations.AddOrUpdate(x=> x.Id, new Information{
                Id=1,
                BirthDate = DateTime.Now,
                FullContent = "Текс полный",
                NickName = "sneqjka",
                SummaryContent = "Половинка текст"
                }
            );
            context.Languages.AddOrUpdate(x => x.Id, new Language
            {
                Id = 1,
                Name = "Английский"
            });
            context.LanguageSkills.AddOrUpdate(x => x.Id, new LanguageSkill
            {

                Id=1,
                InformationId = 1,
                LanguageId = 1,
                Status = LanguageStatus.Intermediate
            });
            context.FIOs.AddOrUpdate(x => new { x.InformationId }, new FIO
            {
                InformationId = 1,
                Id = 1,
                Name = "Снежанна",
                SurName = "Ляхова",
                Patronymic = "Викторовна"
            });  
        }
    }
}
