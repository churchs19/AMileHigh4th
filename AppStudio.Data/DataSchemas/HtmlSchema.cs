using AppStudio.Data.DataSchemas;
using System;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the HtmlSchema class.
    /// </summary>
    public class HtmlSchema : BindableLinkSchemaBase
    {
        private string _content;

        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        public override string DefaultTitle
        {
            get { return null; }
        }

        public override string DefaultSummary
        {
            get { return Content; }
        }

        public override string DefaultImageUrl
        {
            get { return null; }
        }

        public override string DefaultLink
        {
            get { return null; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "id":
                        return String.Format("{0}", Id);
                    case "content":
                        return String.Format("{0}", Content);
                    case "defaulttitle":
                        return String.Format("{0}", DefaultTitle);
                    case "defaultsummary":
                        return String.Format("{0}", DefaultSummary);
                    case "defaultimageurl":
                        return String.Format("{0}", DefaultImageUrl);
                    case "defaultwideimageurl":
                        return String.Format("{0}", DefaultWideImageUrl);
                    default:
                        break;
                }
            }
            return String.Empty;
        }
    }
}
