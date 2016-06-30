using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sneg.Common.Helpers
{
    public class JsonHelper
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
