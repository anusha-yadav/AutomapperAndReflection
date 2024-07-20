namespace ReflectionAndAttributes.Mapper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonIncludeAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class JsonExcludeAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class MapToAttribute : Attribute
    {
        public string TargetProperty { get; }

        public MapToAttribute(string targetProperty)
        {
            TargetProperty = targetProperty;
        }
    }
}
