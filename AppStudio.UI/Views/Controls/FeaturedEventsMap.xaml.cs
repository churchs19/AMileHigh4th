using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using AppStudio.Data;
using AppStudio.Extensions;
using System.Windows.Media;

namespace AppStudio.Views.Controls
{
    public partial class FeaturedEventsMap : UserControl
    {
        public FeaturedEventsMap()
        {
            InitializeComponent();
        }

        private void EventsMap_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "a177bdb9-40d4-4798-aa33-ff8502e885a9";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "nwUPid5_5dE94vJ-pPL10A";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var pushpinTemplate = this.Resources["PushpinTemplate"] as DataTemplate;

            var model = this.DataContext as FeaturedEventsMapViewModel;

            ObservableCollection<DependencyObject> children = Microsoft.Phone.Maps.Toolkit.MapExtensions.GetChildren(EventsMap);
            var obj =
                children.FirstOrDefault(x => x.GetType() == typeof(MapItemsControl)) as MapItemsControl;

            obj.ItemsSource = model.FilteredItems;
        }

        private void EventName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var textBlock = sender as TextBlock;
            if(sender != null)
            {
                var item = textBlock.Tag as FeaturedEventsSchema;
                if(item!=null)
                {
                    if (item.IsSelected)
                    {
                        item.IsSelected = false;
                    }
                    else
                    {
                        var model = this.DataContext as FeaturedEventsMapViewModel;
                        if (model != null)
                        {
                            model.FilteredItems.Remove(item);
                            item.IsSelected = true;
                            model.FilteredItems.Add(item);
                        }
                    }
                }
            }
        }

    }
}
