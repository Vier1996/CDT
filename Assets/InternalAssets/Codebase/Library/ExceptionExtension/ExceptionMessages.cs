﻿using System;
using UnityEngine;

namespace InternalAssets.Codebase.Library.ExceptionExtension
{
    public static class ExceptionMessages
    {
        public static Exception TypeCast<TF, TT>(this object @self) =>
            new ArgumentException($"Invalid cast exception From:[{nameof(TF)}] -> To:[{nameof(TT)}];" + 
                                  $"StackTrace:[{StackTraceUtility.ExtractStackTrace()}]");
    }
}