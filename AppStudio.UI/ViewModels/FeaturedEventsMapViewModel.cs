using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;
using System.Device.Location;
using AppStudio.Commands;

namespace AppStudio.Data
{
    public class FeaturedEventsMapViewModel : ViewModelBase<FeaturedEventsSchema>
    {
        public FeaturedEventsMapViewModel() : base()
        {
            NokiaMapsServices.GetPositionWatcher().PositionChanged += FeaturedEventsMapViewModel_PositionChanged;
        }

        void FeaturedEventsMapViewModel_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            this.UserLocation = e.Position.Location;
        }

        override protected string CacheKey
        {
            get { return "FeaturedEventsMapDataSource"; }
        }

        override protected IDataSource<FeaturedEventsSchema> CreateDataSource()
        {
            return new FeaturedEventsDataSource(); // CollectionDataSource
        }

        public override async System.Threading.Tasks.Task LoadItems(bool isNetworkAvailable)
        {
            await base.LoadItems(isNetworkAvailable);
            foreach(var item in this.Items)
            {
                item.DirectionsCommand = new DirectionsCommand();
                item.ShareCommand = new ShareCommand();
                item.SharePhotoCommand = new SharePhotoCommand();
                item.EventLinkCommand = new EventLinkCommand();
            }
        }

        override public bool IsStaticData
        {
            get { return true; }
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
//            NavigationServices.NavigateToPage("FeaturedEventsDetail");
        }

        private GeoCoordinate _userLocation;
        public GeoCoordinate UserLocation
        {
            get { return _userLocation; }
            set
            {
                SetProperty(ref _userLocation, value);
            }
        }
    }
}
