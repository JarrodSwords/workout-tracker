using System;

namespace workout_tracker.domain
{
    public static class Extensions
    {
        public static T ToEnum<T>(this string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }
    }
}
