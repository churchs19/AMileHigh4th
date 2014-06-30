using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;
using Microsoft.Phone.Tasks;

namespace AppStudio.Data
{
    public class FeaturedEventsViewModel : ViewModelBase<FeaturedEventsSchema>
    {
        override protected string CacheKey
        {
            get { return "FeaturedEventsDataSource"; }
        }

        override protected IDataSource<FeaturedEventsSchema> CreateDataSource()
        {
            return new FeaturedEventsDataSource(); // CollectionDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        public override bool IsGoToSourceVisible
        {
            get
            {
                return ViewType == ViewTypes.Detail;
            }
        }

        public override void GoToSource()
        {
            base.GoToSource("{DefaultLink}");
        }

        override public bool IsShareItemVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void ShareItem()
        {
            base.ShareItem("{DefaultTitle}", "{IAmGoing}", "{DefaultLink}", "{DefaultImageUrl}");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("FeaturedEventsDetail");
        }
    }
}
