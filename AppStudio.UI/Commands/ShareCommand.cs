using AppStudio.Data;
using AppStudio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppStudio.Commands
{
    public class ShareCommand : ICommand
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
            if (item != null)
            {
                ShareServices svc = new ShareServices();
                svc.Share(item.Event_Name, item.IAmGoing, item.Link_1, item.Event_Image);
            }
        }
    }
}
