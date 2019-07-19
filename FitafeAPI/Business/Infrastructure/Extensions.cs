using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Infrastructure
{
    public static class Extensions
    {
        public static Stopwatch StartNow(
          this Stopwatch stopwatch)
        {
            stopwatch.Start();
            return stopwatch;
        }

        public static string GetDescription(this Enum en)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());

            if (memInfo.Length <= 0) return en.ToString();

            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attrs.Length > 0
                ? ((DescriptionAttribute)attrs[0]).Description
                : en.ToString();
        }

        public static string FirstCharacterToLower(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str, 0))
            {
                return str;
            }
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public static string ToNumberString(this Enum e)
        {
            return e.ToString("D");
        }

        public static T With<T>(this T value, params Action<T>[] modifiers)
        {
            foreach (var modify in modifiers)
                modify(value);

            return value;
        }

        public static bool IsNotEmpty(this object o)
        {
            if (o is string s)
                return s != "";

            return o != null;
        }

        public static bool IsNumeric(this Type type)
        {
            if (type == null)
                return false;

            return type.IsPrimitive || type == typeof(decimal);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
                action(obj);
        }

        public static TimeSpan Milliseconds(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds((double)milliseconds);
        }

        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds((double)seconds);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes((double)minutes);
        }

        public static TimeSpan Hours(this int hours)
        {
            return TimeSpan.FromHours((double)hours);
        }

        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays((double)days);
        }
    }
}
