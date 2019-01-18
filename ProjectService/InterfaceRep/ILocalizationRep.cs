using ProjectModelCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectService.InterfaceRep
{
    public interface ILocalizationRep
    {
        string GetResources(string resourcesKey, string resourcelanguage);
        bool ImportFiletoData(string localizationLanguages);
        List<LocalizationLanguages> GetListLocalization(int pageSize, int pageNumber, ref int total);
    }
}
