using AutoMapper;
using ReflectionAndAttributes.Models;

namespace ReflectionAndAttributes.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });  
        }
    }

}
