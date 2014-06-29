using AppStudio.Data;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppStudio.Commands
{
    public class EventLinkCommand : ICommand
    {

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

        public void Execute(object parameter)
        {
            var item = parameter as FeaturedEventsSchema;
            if(item != null && !string.IsNullOrWhiteSpace(item.Link_1))
            {
                WebBrowserTask task = new WebBrowserTask();
                task.Uri = new Uri(item.Link_1);
                task.Show();
            }
        }
    }
}
