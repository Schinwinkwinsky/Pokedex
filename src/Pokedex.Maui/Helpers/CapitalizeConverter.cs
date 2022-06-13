using System.Globalization;

namespace Pokedex.Maui.Helpers
{
    public class CapitalizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var word = value as string;

            return word.Substring(0, 1).ToUpper() + word.Substring(1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var word = value as string;

            return word.Substring(0, 1).ToLower() + word.Substring(1);
        }
    }
}
