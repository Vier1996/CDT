using System;
using UnityEngine;

namespace InternalAssets.Codebase.Library.ExceptionExtension
{
    public static class ExceptionMessages
    {
        public static Exception TypeCast<TF, TT>(this object @self) =>
            new ArgumentException($"Invalid cast exception From:[{nameof(TF)}] -> To:[{nameof(TT)}]");
        
        public static Exception MissedAttribute<T>(this object @self) =>
            new ArgumentException($"Missing attribute exception Type:[{nameof(T)}]");
        
        public static Exception MissedComponent<T>(this object @self) =>
            new ArgumentException($"Missing attribute exception Type:[{nameof(T)}]");
        
        public static Exception MissedComponent(this object @self, Type componentType) =>
            new ArgumentException($"Missing attribute exception Type:[{componentType.Name}]");
    }
}