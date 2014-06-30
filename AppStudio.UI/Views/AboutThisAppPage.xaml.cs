
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using AppStudio.Data;

namespace AppStudio.Views
{
    public partial class AboutThisAppPage : PhoneApplicationPage
    {
        public AboutThisAppPage()
        {
            InitializeComponent();

            this.DataContext = AboutThisAppViewModel.Current;
        }
    }
}
