using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ReflectionAndAttributes.Mapper;
using System.Reflection;

namespace ReflectionAndAttributes.Services
{
    public class CustomJsonContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            return properties.Where(p => ShouldSerialize(p)).ToList();
        }

        private bool ShouldSerialize(JsonProperty property)
        {
            var propInfo = property.DeclaringType.GetProperty(property.UnderlyingName);

            if (propInfo.GetCustomAttribute<JsonExcludeAttribute>() != null)
            {
                return false;
            }

            if (propInfo.GetCustomAttribute<JsonIncludeAttribute>() != null)
            {
                return true;
            }
            return true;
        }
    }
}
