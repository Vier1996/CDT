using System;

namespace InternalAssets.Codebase.Library.ExceptionExtension
{
    public class ExceptionMessages
    {
        public static string Cast<TF, TT>() => $"Invalid cast exception From:[{nameof(TF)}] -> To:[{nameof(TT)}]";
    }
}