using System;

namespace BadPanda.FontManager.Extentions
{
    public static class Extentions
    {
        public static U Then<T, U>(this T @this, Func<T, U> fn) => fn(@this);
    }
}