using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class PhotosViewModel : ViewModelBase<PhotosSchema>
    {
        override protected string CacheKey
        {
            get { return "PhotosDataSource"; }
        }

        override protected IDataSource<PhotosSchema> CreateDataSource()
        {
            return new PhotosDataSource(); // CollectionDataSource
        }

        override public bool IsPinToStartVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }

        override public void PinToStart()
        {
            base.PinToStart("PhotosDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}", "{DefaultWideImageUrl}");
        }

        override public bool IsShareItemVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void ShareItem()
        {
            base.ShareItem("{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}", "{DefaultImageUrl}");
        }

        override public bool IsRefreshVisible
        {
            get { return ViewType == ViewTypes.List; }
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("PhotosDetail");
        }
    }
}
