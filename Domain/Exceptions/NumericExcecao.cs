using System.Numerics;

namespace Domain.Exceptions
{
    public static class NumericExcecao
    {
        public static void ThrowIfNegativeOrZero<T>(string paramName, T value, string message) where T : INumberBase<T>
        {
            if (T.IsNegative(value) || T.IsZero(value))
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }
        }

        public static void ThrowIfLessThanOrEqual<T>(string paramName,T value, T other, string message) where T : IComparable<T>
        {

            if (value.CompareTo(other) <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, value, message);
            }
                
        }
    }
}
