using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudio.Services
{
    public static class ImageServices
    {
        public static Task<PhotoResult> ChoosePhoto()
        {
            TaskCompletionSource<PhotoResult> tcs = new TaskCompletionSource<PhotoResult>();
            PhotoChooserTask t = new PhotoChooserTask();
            t.ShowCamera = true;
            t.Completed += (s, e) =>
            {
                tcs.TrySetResult(e);
            };
            t.Show();
            return tcs.Task;
        }
    }
}
