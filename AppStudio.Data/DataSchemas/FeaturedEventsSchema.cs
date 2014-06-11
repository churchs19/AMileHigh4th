using System;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the FeaturedEventsSchema class.
    /// </summary>
    public class FeaturedEventsSchema : BindableSchemaBase
    {
        private string _event_Name;
        private string _event_Date;
        private string _event_Cost;
        private string _event_Location;
        private string _event_Description;
        private string _link_1;
        private string _link_2;
        private string _event_Image;
         
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

        public override string DefaultTitle
        {
            get { return Event_Name; }
        }

        public override string DefaultSummary
        {
            get { return Event_Date; }
        }

        public override string DefaultImageUrl
        {
            get { return Event_Image; }
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
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }
    }
}
