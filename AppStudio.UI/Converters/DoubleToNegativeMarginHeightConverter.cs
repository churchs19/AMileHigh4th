using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AppStudio.Converters
{
    public class DoubleToNegativeMarginHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double dbl = (double)value;
                return new Thickness(0, -dbl, 0, 0);
            }
            catch
            {
                return new Thickness(0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
