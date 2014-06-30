using System.Threading.Tasks;
using System.Windows.Input;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public class MainViewModels : BindableBase
    {
       private ADenver4ThViewModel _aDenver4ThModel;
       private FeaturedEventsViewModel _featuredEventsModel;
       private FeaturedEventsMapViewModel _featuredEventsMapModel;
       private AllEventsViewModel _allEventsModel;
       private FreeEventsViewModel _freeEventsModel;
       private MenuSectionViewModel _menuSectionModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModels()
        {
            _selectedItem = ADenver4ThModel;
        }
 
        public ADenver4ThViewModel ADenver4ThModel
        {
            get { return _aDenver4ThModel ?? (_aDenver4ThModel = new ADenver4ThViewModel()); }
        }
 
        public FeaturedEventsViewModel FeaturedEventsModel
        {
            get { return _featuredEventsModel ?? (_featuredEventsModel = new FeaturedEventsViewModel()); }
        }

        public FeaturedEventsMapViewModel FeaturedEventsMapModel
        {
            get { return _featuredEventsMapModel ?? (_featuredEventsMapModel = new FeaturedEventsMapViewModel()); }
        }
 
        public AllEventsViewModel AllEventsModel
        {
            get { return _allEventsModel ?? (_allEventsModel = new AllEventsViewModel()); }
        }
 
        public FreeEventsViewModel FreeEventsModel
        {
            get { return _freeEventsModel ?? (_freeEventsModel = new FreeEventsViewModel()); }
        }
  
        public MenuSectionViewModel MenuSectionModel
        {
            get { return _menuSectionModel ?? (_menuSectionModel = new MenuSectionViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            ADenver4ThModel.ViewType = viewType;
            FeaturedEventsModel.ViewType = viewType;
            FeaturedEventsMapModel.ViewType = viewType;
            AllEventsModel.ViewType = viewType;
            FreeEventsModel.ViewType = viewType;
            MenuSectionModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public bool IsAppBarVisible
        {
            get
            {
                if (SelectedItem == null || SelectedItem == ADenver4ThModel)
                {
                    return true;
                }
                return SelectedItem != null ? SelectedItem.IsAppBarVisible : false;
            }
        }

        public bool IsAboutVisible
        {
            get { return SelectedItem == null || SelectedItem == ADenver4ThModel; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("IsAppBarVisible");
            OnPropertyChanged("IsAboutVisible");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                ADenver4ThModel.LoadItems(isNetworkAvailable),
                FeaturedEventsModel.LoadItems(isNetworkAvailable),
                FeaturedEventsMapModel.LoadItems(isNetworkAvailable),
                AllEventsModel.LoadItems(isNetworkAvailable),
                FreeEventsModel.LoadItems(isNetworkAvailable),
                MenuSectionModel.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand LockScreenCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LockScreenServices.SetLockScreen("/Assets/LockScreenImage.jpg");
                });
            }
        }
    }
}
