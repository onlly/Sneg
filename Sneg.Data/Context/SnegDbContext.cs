using Sneg.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Data.Context
{
    public class SnegDbContext : DbContext
    {
        public SnegDbContext()
            : this("name=CvBuilderEntities")
        {

        }

        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<FIO> FIOs { get; set; }
        public virtual DbSet<Information> Informations { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageSkill> LanguageSkills { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }


        public SnegDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
