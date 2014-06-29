using AppStudio.Data;
using AppStudio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;

namespace AppStudio.Commands
{
    public class DirectionsCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

        public async void Execute(object parameter)
        {
            var param = parameter as FeaturedEventsSchema;
            if(param!=null)
            {
                var uri = string.Concat("directions://v2.0/route/destination/?latlon=", param.Latitude, ",", param.Longitude);

                await Launcher.LaunchUriAsync(new Uri(uri));
            }
        }
    }
}
