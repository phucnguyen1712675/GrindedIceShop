using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace GrindedIceShop.Converter
{
    public class DecimalToCurrencyConverter : IValueConverter
    {
        private static readonly List<string> BadWordList;

        static DecimalToCurrencyConverter()
        {
            BadWordList = new List<string>()
            {
                " đồng",
                "."
            };
        }

        private static string GetNumbers(string input) => new string(input.Where(char.IsDigit).ToArray());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue || value == null) return value;
            var money = (decimal)value;
            return money != 0 ? money.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat) + BadWordList[0] : money.ToString(CultureInfo.InvariantCulture) + BadWordList[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var money = (string)value;
            money = BadWordList.Aggregate(money, (current, badWord) => current.Replace(badWord, string.Empty));
            if (money.All(char.IsDigit) || string.IsNullOrEmpty(money)) return money;
            money = GetNumbers(money);
            return double.Parse(money, CultureInfo.InvariantCulture);
        }
    }
}
