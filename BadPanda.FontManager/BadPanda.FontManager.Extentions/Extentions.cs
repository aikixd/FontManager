using SharpToolkit.FunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadPanda.FontManager.Extentions
{
    public static class Extentions
    {
        //public static U Then<T, U>(this T @this, Func<T, U> fn) => fn(@this);



        public static Result<U> Then<T, U>(this Result<T> result, Func<T, Result<U>> fn) =>
            result.Match(
                ok => fn(ok.Value),
                err => new Result.Error(err.Value));

        public static Result<T> AsOkResult<T>(this T obj)
        {
            return new Result<T>.Ok(obj);
        }
    }

    public class ResultMonad<TIn, TOut>
    {
        public ResultMonad()
        {

        }
    }
}