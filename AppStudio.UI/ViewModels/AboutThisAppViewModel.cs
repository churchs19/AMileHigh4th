using System;
using System.Xml.Linq;
using System.Windows.Input;

using AppStudio.Services;
using AppStudio.Commands;
using Microsoft.Phone.Tasks;

namespace AppStudio.Data
{
    public class AboutThisAppViewModel
    {
        static private AboutThisAppViewModel _current = null;
        static private ShareServices _shareService = new ShareServices();

        private AboutThisAppViewModel()
        {
            RateAppCommand = new RateThisAppCommand();
            SupportEmailCommand = new SendAnEmailCommand();
            OtherAppsCommand = new OtherAppsCommand();
        }

        static public AboutThisAppViewModel Current
        {
            get { return _current ?? (_current = new AboutThisAppViewModel()); }
        }

        public string DeveloperName
        {
            get
            {
                return XDocument.Load("WMAppManifest.xml").Root.Element("App").Attribute("Author").Value;
            }
        }

        public string AppVersion
        {
            get
            {
                return XDocument.Load("WMAppManifest.xml").Root.Element("App").Attribute("Version").Value;
            }
        }

        public string AboutText
        {
            get
            {
                return "There’s no better place to be over the 4th of July than in Denver!\n\n"+
                    "This app uses data from Visit Denver, but is in no way affiliated with Visit Denver or the City and County of Denver." +
                    "This app and its developer are not responsible for any inaccurate information.";
            }
        }

        public bool AppInMarketplace
        {
            get
            {
                return _shareService.AppExistInMarketPlace();
            }
        }

        public ICommand ShareAppCommand
        {
            get
            {
                return new RelayCommand<string>((src) =>
                {
                    if (_shareService.AppExistInMarketPlace())
                    {
                        string appUri = Windows.ApplicationModel.Store.CurrentApp.LinkUri.AbsoluteUri;
                        _shareService.Share("A Mile High 4th", "Check out A Mile High 4th in the Windows Phone Store!", appUri, string.Empty);
                    }
                });
            }
        }

        public ICommand RateAppCommand { get; private set; }
        public ICommand SupportEmailCommand { get; private set; }
        public ICommand OtherAppsCommand { get; private set; }
        public ICommand GoToSChurchNetCommand {
            get
            {
                return new RelayCommand<string>((param) =>
                {
                    WebBrowserTask task = new WebBrowserTask();
                    task.Uri = new Uri("http://www.s-church.net");
                    task.Show();
                });
            }
        }
    }
}
