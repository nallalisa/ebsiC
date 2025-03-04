using ebsiC.Assets.Classes;
using ebsiC.Assets.MVVM.Model;
using System.Collections.ObjectModel;
using ebsiC.Assets.MVVM.View.userControl;
using System.Windows;
using System.Windows.Input;

namespace ebsiC.Assets.MVVM.ViewModel
{
    public class DashboardVM : ObservableObject
    {
        private string _pageTitle;
        private object _currentView;
        public ICommand NavigateCommand { get; }

        private int _columnCount;

        public ObservableCollection<DataGridItem> DataGridItems { get; set; }

        public int ColumnCount
        {
            get => _columnCount;
            set
            {
                _columnCount = value;
                OnPropertyChanged(nameof(ColumnCount));
            }
        }

        public ObservableCollection<DashboardCardVM> Cards { get; set; }

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


        private void UpdateColumnCount()
        {
            double screenWidth = SystemParameters.WorkArea.Width;
            ColumnCount = (int)screenWidth / 300;
            ColumnCount = ColumnCount < 1 ? 1 : ColumnCount;
        }


        public DashboardVM()
        {
            PageTitle = "Dashboard";
            Cards = new ObservableCollection<DashboardCardVM>();

            Cards.Add(new DashboardCardVM(new DashboardCardModel("#94cdf7", "Employees", "1000", "Account")));
            Cards.Add(new DashboardCardVM(new DashboardCardModel("#ffcc00", "Active", "2000", "CheckCircle")));
            Cards.Add(new DashboardCardVM(new DashboardCardModel("#ff5733", "Leave", "3000", "ClockOutline")));

            UpdateColumnCount();
            ColumnCount = 3;

            

            CurrentView = new DashboardView();

            NavigateCommand = new RelayCommand(Navigate);

            DataGridItems = new ObservableCollection<DataGridItem>
            {
                new DataGridItem { ID = 1, Name = "John Doe", Age = 25, Department = "HR" },
                new DataGridItem { ID = 2, Name = "Jane Smith", Age = 30, Department = "Finance" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
                new DataGridItem { ID = 3, Name = "Alice Johnson", Age = 28, Department = "IT" },
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

        private void Navigate(object obj)
        {
            if (obj is string viewName)
            {
                switch(viewName)
                {
                    case "Dashboard":
                        PageTitle = "Dashboard";
                        CurrentView = new DashboardView();
                        break;
                    case "Time Keeping":
                        PageTitle = "Time Keeping";
                        CurrentView = new TimeKeepingView();
                        break;
                    case "Active":
                        //CurrentView = new ActiveView();
                        break;
                    case "Leave":
                        //CurrentView = new LeaveView();
                        break;
                    default:
                        CurrentView = new DashboardView();
                        break;
                }
            }
        }
    }
}
