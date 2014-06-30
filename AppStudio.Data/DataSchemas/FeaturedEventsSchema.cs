using AppStudio.Data.DataSchemas;
using System;
using System.Device.Location;
using System.Windows.Input;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the FeaturedEventsSchema class.
    /// </summary>
    public class FeaturedEventsSchema : BindableLinkSchemaBase
    {
        private string _event_Name;
        private string _event_Date;
        private string _event_Cost;
        private string _event_Location;
        private string _event_Description;
        private string _link_1;
        private string _link_2;
        private string _event_Image;
        private double _latitude = 39.74001;
        private double _longitude = -104.9923;
         
        public string Event_Name
        {
            get { return _event_Name; }
            set { SetProperty(ref _event_Name, value); }
        }
 
        public string Event_Date
        {
            get { return _event_Date; }
            set { SetProperty(ref _event_Date, value); }
        }
 
        public string Event_Cost
        {
            get { return _event_Cost; }
            set { SetProperty(ref _event_Cost, value); }
        }
 
        public string Event_Location
        {
            get { return _event_Location; }
            set { SetProperty(ref _event_Location, value); }
        }
 
        public string Event_Description
        {
            get { return _event_Description; }
            set { SetProperty(ref _event_Description, value); }
        }
 
        public string Link_1
        {
            get { return _link_1; }
            set { SetProperty(ref _link_1, value); }
        }
 
        public string Link_2
        {
            get { return _link_2; }
            set { SetProperty(ref _link_2, value); }
        }
 
        public string Event_Image
        {
            get { return _event_Image; }
            set { SetProperty(ref _event_Image, value); }
        }

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                if (SetProperty(ref _latitude, value))
                {
                    OnPropertyChanged("GeoCoordinate");
                }
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set 
            { 
                if(SetProperty(ref _longitude, value))
                {
                    OnPropertyChanged("GeoCoordinate");
                }
            }
        }

        public bool IsFree
        {
            get { return Event_Cost.ToLower() == "free"; }
        }

        public GeoCoordinate GeoCoordinate
        {
            get
            {
                return new GeoCoordinate(Latitude, Longitude);
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        public ICommand DirectionsCommand { get; set; }
        public ICommand ShareCommand { get; set; }
        public ICommand SharePhotoCommand { get; set; }
        public ICommand EventLinkCommand { get; set; }

        public override string DefaultTitle
        {
            get { return Event_Name; }
        }

        public override string DefaultSummary
        {
            get { return Event_Description; }
        }

        public override string DefaultImageUrl
        {
            get { return Event_Image; }
        }

        public override string DefaultLink
        {
            get { return Link_1; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "event_name":
                        return String.Format("{0}", Event_Name); 
                    case "event_date":
                        return String.Format("{0}", Event_Date); 
                    case "event_cost":
                        return String.Format("{0}", Event_Cost); 
                    case "event_location":
                        return String.Format("{0}", Event_Location); 
                    case "event_description":
                        return String.Format("{0}", Event_Description); 
                    case "link_1":
                        return String.Format("{0}", Link_1); 
                    case "link_2":
                        return String.Format("{0}", Link_2); 
                    case "event_image":
                        return String.Format("{0}", Event_Image); 
                    case "isfree":
                        return String.Format("{0}", IsFree);
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    case "latitude":
                        return String.Format("{0}", Latitude);
                    case "longitude":
                        return String.Format("{0}", Longitude);
                    case "geocoordinate":
                        return String.Format("{0}", GeoCoordinate);
                    default:
                        break;
                }
            }
            return String.Empty;
        }
    }
}
