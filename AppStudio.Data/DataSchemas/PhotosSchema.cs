using System;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the PhotosSchema class.
    /// </summary>
    public class PhotosSchema : BindableSchemaBase
    {
        private string _title;
        private string _caption;
        private string _image;
         
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
 
        public string Caption
        {
            get { return _caption; }
            set { SetProperty(ref _caption, value); }
        }
 
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public override string DefaultTitle
        {
            get { return Title; }
        }

        public override string DefaultSummary
        {
            get { return Caption; }
        }

        public override string DefaultImageUrl
        {
            get { return Image; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "title":
                        return String.Format("{0}", Title); 
                    case "caption":
                        return String.Format("{0}", Caption); 
                    case "image":
                        return String.Format("{0}", Image); 
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
