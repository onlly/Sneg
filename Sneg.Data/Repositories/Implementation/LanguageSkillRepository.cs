using Sneg.Data.Context;
using Sneg.Data.Entities;
using Sneg.Data.Repositories.Interfaces;

namespace Sneg.Data.Repositories.Implementation
{
    public class LanguageSkillRepository:RepositoryBase<LanguageSkill>,ILanguageSkill
    {
        public LanguageSkillRepository(SnegDbContext context) : base(context)
        {

        }
    }
}
