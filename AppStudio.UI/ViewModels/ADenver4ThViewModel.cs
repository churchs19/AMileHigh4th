using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class ADenver4ThViewModel : ViewModelBase<HtmlSchema>
    {
        override protected string CacheKey
        {
            get { return "ADenver4ThDataSource"; }
        }

        override protected IDataSource<HtmlSchema> CreateDataSource()
        {
            return new ADenver4ThDataSource(); // HtmlDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        override public ViewTypes ViewType
        {
            get { return ViewTypes.Detail; }
        }

        override public bool IsPinToStartVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }

        override public void PinToStart()
        {
            base.PinToStart("MainPage", "A Denver 4th", "{Content}", "");
        }

        override public bool IsShareItemVisible
        {
            get { return false; }
        }
        
        override public void ShareItem()
        {
            base.ShareItem("A Denver 4th", "{Content}", "", "");
        }

        override public bool IsSpeakTextVisible
        {
            get { return false; }
        }
        
        override public void SpeakText()
        {
            base.SpeakText("Content");
        }
    }
}
