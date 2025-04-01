using ebsiC.Assets.Classes;
using ebsiC.Assets.MVVM.Model;
using ebsiC.Assets.MVVM.View.admin;
using ebsiC.Assets.MVVM.View.userControl;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ebsiC.Assets.MVVM.ViewModel
{
    public class DashboardVM : ObservableObject
    {
        private string _pageTitle;
        private object _currentView;
        private Navigation _selectedNavigation;

        public ICommand NavigateCommand { get; }
        public ObservableCollection<DataGridItem> DataGridItems { get; set; }
        public ObservableCollection<DashboardCardVM> Cards { get; set; }
        public ObservableCollection<Navigation> SampleList { get; set; }

        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                OnPropertyChanged(nameof(PageTitle));
            }
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }

        public Navigation SelectedNavigation
        {
            get => _selectedNavigation;
            set
            {
                if (_selectedNavigation != value)
                {
                    _selectedNavigation = value;
                    OnPropertyChanged(nameof(SelectedNavigation));
                    NavigateToSelectedView();
                }
            }
        }
        public DashboardVM()
        {
            PageTitle = "Dashboard";

            Cards = new ObservableCollection<DashboardCardVM>
            {
                new DashboardCardVM(new DashboardCardModel("#94cdf7", "Employees", "1000", "Account")),
                new DashboardCardVM(new DashboardCardModel("#ffcc00", "Active", "2000", "CheckCircle")),
                new DashboardCardVM(new DashboardCardModel("#ff5733", "Leave", "3000", "ClockOutline"))
            };

            //ADDING NAVIGATION
            SampleList = new ObservableCollection<Navigation>
            {
                new Navigation { Title = "Dashboard", SelectedIcon = "ViewDashboard", UnselectedIcon = "ViewDashboardOutline" },
                new Navigation { Title = "Attendance", SelectedIcon = "ClockCheck", UnselectedIcon = "ClockOutline" },
                new Navigation { Title = "Payroll" },
                new Navigation { Title = "Administration" }
            };

            SelectedNavigation = SampleList[0];

            InitializeDataGridItems();
        }

        private void NavigateToSelectedView()
        {
            switch (SelectedNavigation?.Title)
            {
                case "Dashboard":
                    CurrentView = new DashboardView();
                    PageTitle = "Dashboard";
                    break;
                case "Attendance":
                    CurrentView = new TimeKeepingView();
                    PageTitle = "Attendance";
                    break;
                case "Payroll":
                    CurrentView = new Administration();
                    PageTitle = "NewEmployeeForm";
                    break;
                case "Administration":
                    CurrentView = new Administration();
                    PageTitle = "Administration";
                    break;
                default:
                    CurrentView = new DashboardView();
                    PageTitle = "Dashboard";
                    break;
            }
        }

        private void InitializeDataGridItems()
        {
            DataGridItems = new ObservableCollection<DataGridItem>
            {
                new DataGridItem { ID = 1, Name = "John Doe", Age = 25, Department = "HR" },
                new DataGridItem { ID = 2, Name = "Jane Smith", Age = 30, Department = "Finance" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 4, Name = "Bob Brown", Age = 35, Department = "Sales" }
            };
        }

        public class DataGridItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Department { get; set; }
        }
    }
}
