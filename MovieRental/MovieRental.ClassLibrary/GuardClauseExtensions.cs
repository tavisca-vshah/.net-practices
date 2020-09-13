using System;

namespace MovieRental.ClassLibrary
{
    public static class GuardClauseExtensions
    {
        public static void NullOrWhiteSpace(this IGuardClause guardClause, string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{parameterName} cannot be null or empty");
            }
        }

        public static void LessThanZero(this IGuardClause guardClause, int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Argument must Greater than or equal to Zero");
            }
        }

        public static void Null<T>(this IGuardClause guardClause, T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{parameterName} cannot be null");
            }
        }
    }
}
