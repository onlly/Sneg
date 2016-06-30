using Sneg.Data.Entities;
using Sneg.Data.Repositories.Interfaces;
using Sneg.Service.Dto;
using Sneg.Service.Interfaces;
using Sneg.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Service.Implementation
{
    public class InformationService : ServiceBase<Information>, IInformationService
    {
        public InformationService(IInformationRepository infoRepository) : base(infoRepository)
        {

        }

        public IEnumerable<InformationMinDto> GetInfrormationInfos()
        {
            var info = Repository.Query()
                .SelectMinDto()
                .OrderBy(x => x.Name)
                .ToList();
            return info;
        }
    }
}
