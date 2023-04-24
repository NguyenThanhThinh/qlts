using System;

namespace qlts.Extensions
{
    public static class MoneyExtensions
    {
        public static string ToMoneyFormatted(this decimal money, string postFix = "")
            => money.ToString("N0") + (string.IsNullOrEmpty(postFix) ? string.Empty : " " + postFix);

        public static decimal ToMoney(this string money, int defaultValue = 0)
        {
            decimal val;

            if (decimal.TryParse(money, out val))
                return val;
            

            return defaultValue;
        }

        /// <summary>
        /// Round a decimal into integer
        /// </summary>
        /// <param name="money">The input value</param>
        /// <param name="unit">The unit of a money system. This is the minimum value in a money system.</param>
        /// <param name="min">
        /// The minimum value to compare. Default it is equal to unit
        /// </param>
        /// <returns>The rounded money</returns>
        public static int ToRoundMoney(this decimal money, int unit = 0, int min = 0)
        {
            if (money == 0)
                return 0;

            var negative = money < 0;

            money = Math.Abs(money);
            var val = (int)Math.Round(money, MidpointRounding.ToEven);
            var mod = val % Math.Max(unit, 1);

            if (mod >= min)
                val = val - mod + unit;
            else
                val = val - mod;

            return negative ? -val : val;
        }

        /// <summary>
        /// Round money in Vietnam money system
        /// </summary>
        /// <param name="money">The input value</param>
        /// <returns>The rounded money</returns>
        public static decimal ToVnd(this decimal money)
        {
            return money.ToRoundMoney(500, 200);
        }
    }
}