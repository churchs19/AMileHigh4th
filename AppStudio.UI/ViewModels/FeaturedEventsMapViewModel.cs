using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;
using System.Device.Location;
using AppStudio.Commands;
using System.Collections.ObjectModel;

namespace AppStudio.Data
{
    public class FeaturedEventsMapViewModel : ViewModelBase<FeaturedEventsSchema>
    {
        public FeaturedEventsMapViewModel() : base()
        {
            NokiaMapsServices.GetPositionWatcher().PositionChanged += FeaturedEventsMapViewModel_PositionChanged;
            FilteredItems.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged("FilteredItems");
            };
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
            FilterItems();
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

        private EventTypeFilter _eventType = EventTypeFilter.All;
        public EventTypeFilter EventType
        {
            get { return _eventType; }
            set
            {
                if (SetProperty(ref _eventType, value))
                {
                    FilterItems();
                    OnPropertyChanged("FilterTypeImage");
                }
            }
        }

        private void FilterItems()
        {
            FilteredItems.Clear();
            var query = Items.AsEnumerable();
            if (EventType == EventTypeFilter.Paid)
            {
                query = Items.Where(it => !it.IsFree);
            }
            else if (EventType == EventTypeFilter.Free)
            {
                query = Items.Where(it => it.IsFree);
            }
            foreach (var item in query)
            {
                FilteredItems.Add(item);
            }
        }

        private ObservableCollection<FeaturedEventsSchema> _filteredItems = new ObservableCollection<FeaturedEventsSchema>();
        public ObservableCollection<FeaturedEventsSchema> FilteredItems
        {
            get { return _filteredItems; }
            private set
            {
                SetProperty(ref _filteredItems, value);
            }
        }

        protected override void ToggleFilter()
        {
            if (this.EventType == EventTypeFilter.All)
                EventType = EventTypeFilter.Paid;
            else if (this.EventType == EventTypeFilter.Paid)
                EventType = EventTypeFilter.Free;
            else
                EventType = EventTypeFilter.All;

            base.ToggleFilter();
        }

        public override string FilterTypeImage
        {
            get
            {
                if (EventType == EventTypeFilter.All)
                    return "/Assets/AllFilter.png";
                else if (EventType == EventTypeFilter.Paid)
                    return "/Assets/PaidFilter.png";
                else
                    return "/Assets/FreeFilter.png";
            }
        }

    }
}
