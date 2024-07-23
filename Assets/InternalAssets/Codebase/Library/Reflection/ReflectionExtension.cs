using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.Utilities;

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
        
        public static IEnumerable<Type> GetAllInheritsTypes(this Type inputType)
        {
            Assembly currentAssembly = AppDomain.CurrentDomain.GetAssemblies().First(atr => atr.GetName().Name.Equals("Assembly-CSharp"));
            
            return currentAssembly.GetTypes().Where(tp => tp != inputType && tp.InheritsFrom(inputType));
        }
    }
}