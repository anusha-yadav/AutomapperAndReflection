using ReflectionAndAttributes.Mapper;

namespace ReflectionAndAttributes.Models
{
    public class EmployeeDTO
    {
        [JsonExclude]
        public int Id { get; set; }

        [JsonInclude]
        public string Name { get; set; }

        [JsonInclude]
        public string JobTitle { get; set; }
        [JsonExclude]
        public string Department { get; set; }

        [JsonExclude]
        public decimal Experience { get; set; }
    }
}
