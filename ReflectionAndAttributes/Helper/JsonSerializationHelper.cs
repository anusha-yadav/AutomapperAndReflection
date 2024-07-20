using Newtonsoft.Json;
using ReflectionAndAttributes.Services;

namespace ReflectionAndAttributes.Helper
{
    public static class JsonSerializationHelper
    {
        public static string SerializeToJson(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CustomJsonContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T DeserializeFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
