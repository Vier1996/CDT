using System;
using System.Linq;

namespace InternalAssets.Codebase.Library.Reflection
{
    public static class ReflectionExtension
    {
        public static T GetAttribute<T>(this object @object) where T : Attribute =>
            @object
                .GetType()
                .GetCustomAttributes(false)
                .OfType<T>()
                .SingleOrDefault();
        
        public static T GetAttribute<T>(this Type @type) where T : Attribute =>
            @type
                .GetCustomAttributes(false)
                .OfType<T>()
                .SingleOrDefault();
        
        public static bool TryGetAttribute<T>(this Type @type, out T attribute) where T : Attribute =>
            (attribute = @type
                .GetCustomAttributes(false)
                .OfType<T>()
                .SingleOrDefault()) != default;
    }
}