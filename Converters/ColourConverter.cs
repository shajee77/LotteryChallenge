using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LotteryProgrammingChallenge.Converters
{
    public class ColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = int.Parse(value.ToString());

            if(val >= 1 && val <= 9)
                return new SolidColorBrush(Colors.Gray);
            else if(val >= 10 && val <= 19)
                return new SolidColorBrush(Colors.Blue);
            else if (val >= 20 && val <= 29)
                return new SolidColorBrush(Colors.Pink);
            else if (val >= 30 && val <= 39)
                return new SolidColorBrush(Colors.Green);
            else if (val >= 40 && val <= 49)
                return new SolidColorBrush(Colors.Yellow);
            else
                return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
