using AppStudio.Data;
using AppStudio.Services;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppStudio.Commands
{
    public class SharePhotoCommand : ICommand
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
            var item = parameter as FeaturedEventsSchema;
            if(item!=null)
            {
                var result = await ImageServices.ChoosePhoto();
                if (result.Error != null || result.TaskResult != Microsoft.Phone.Tasks.TaskResult.OK)
                {
                    return;
                }
                else
                {
                    ShareMediaTask smt = new ShareMediaTask();
                    smt.FilePath = result.OriginalFileName;
                    smt.Show();
                }
            }
        }
    }
}
