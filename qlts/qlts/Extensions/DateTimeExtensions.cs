using System;
using System.Globalization;

namespace qlts.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Try parse input datetime string into datetime using specific culture
        /// </summary>
        /// <param name="dateString">a string of datetime to parse</param>
        /// <param name="format">dateString input format</param>
        /// <param name="culture">specify culture info to parse</param>
        /// <returns>return DateTime if parse success, otherwise return null</returns>
        public static DateTime? ToDateTime(this string dateString, string format = "dd/MM/yyyy", string culture = "vi-vn")
        {
            var succeed = DateTime.TryParseExact(dateString, format, CultureInfo.CreateSpecificCulture(culture), DateTimeStyles.None, out var dt);

            if (succeed)
                return dt;

            return null;
        }
    }
}