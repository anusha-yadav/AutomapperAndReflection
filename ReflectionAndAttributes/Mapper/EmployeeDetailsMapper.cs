using AutoMapper;
using System.Reflection;

namespace ReflectionAndAttributes.Mapper
{
    public class EmployeeDetailsMapper
    {
        /// <summary>
        /// Using reflection 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void MapProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProp in sourceProperties)
            {
                var mapToAttr = sourceProp.GetCustomAttribute<MapToAttribute>();
                var targetPropName = mapToAttr?.TargetProperty ?? sourceProp.Name;

                var destProp = Array.Find(destinationProperties, p => p.Name == targetPropName);

                if (destProp != null && destProp.CanWrite)
                {
                    destProp.SetValue(destination, sourceProp.GetValue(source));
                }
            }
        }

        /// <summary>
        /// Using Automapper
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void MappingProfile<TSource, TDestination>(TSource source, TDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            var mapper = config.CreateMapper();
            mapper.Map(source, destination);
        }

    }

}
