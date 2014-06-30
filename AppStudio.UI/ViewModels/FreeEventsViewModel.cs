using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class FreeEventsViewModel : ViewModelBase<RssSchema>
    {
        override protected string CacheKey
        {
            get { return "FreeEventsDataSource"; }
        }

        override protected IDataSource<RssSchema> CreateDataSource()
        {
            return new FreeEventsDataSource(); // RssDataSource
        }

        override public bool IsPinToStartVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }

        override public void PinToStart()
        {
            base.PinToStart("FreeEventsDetail", "{Title}", "{Summary}", "{ImageUrl}");
        }

        override public bool IsShareItemVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void ShareItem()
        {
            base.ShareItem("{Title}", "{IAmGoing}", "{FeedUrl}", "{ImageUrl}");
        }

        override public bool IsGoToSourceVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void GoToSource()
        {
            base.GoToSource("{FeedUrl}");
        }

        override public bool IsRefreshVisible
        {
            get { return ViewType == ViewTypes.List; }
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("FreeEventsDetail");
        }
    }
}
