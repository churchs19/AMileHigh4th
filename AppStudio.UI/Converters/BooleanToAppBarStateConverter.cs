using Cimbalino.Phone.Toolkit.Behaviors;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AppStudio.Converters
{
    public class BooleanToAppBarStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                bool b = (bool)value;
                return b ? ApplicationBarMode.Default : ApplicationBarMode.Minimized;
            }
            catch
            {
                return ApplicationBarMode.Minimized;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
