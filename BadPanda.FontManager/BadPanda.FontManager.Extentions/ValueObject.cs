using System;
using SharpToolkit.FunctionalExtensions;

namespace BadPanda.FontManager.Extentions
{
    public class ValueObject<T>
    {
        public T Value { get; private set; }

        public ValueObject(T value)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Validate(value)
                .Match(
                    _ => Value = value,
                    r => throw new ArgumentException(r.Value.Message));

        }

        protected virtual Result Validate(T value)
        {
            return new Result.Ok();
        }
    }
}
