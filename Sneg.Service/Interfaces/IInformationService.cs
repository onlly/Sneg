using Sneg.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Service.Interfaces
{
    public interface IInformationService
    {
        IEnumerable<InformationMinDto> GetInfrormationInfos();
    }
}
