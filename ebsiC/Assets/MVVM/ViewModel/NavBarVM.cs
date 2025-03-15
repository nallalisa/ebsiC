using ebsiC.Assets.MVVM.Model;
using System.Collections.ObjectModel;

namespace ebsiC.Assets.MVVM.ViewModel
{
    
    public class NavBarVM
    {
        public ObservableCollection<Navigation> SampleList { get; set; }

        public NavBarVM()
        {
            SampleList = new ObservableCollection<Navigation>
            {
                new Navigation { Title = "Dashboard", SelectedIcon = "ViewDashboard", UnselectedIcon = "ViewDashboardOutline"},
                new Navigation { Title = "Time Keeping", SelectedIcon = "ClockCheck", UnselectedIcon = "ClockOutline"},
                new Navigation { Title = "Payroll", SelectedIcon = "Bank", UnselectedIcon = "BankOutline"},
                new Navigation { Title = "Administrator", SelectedIcon = "ShieldAccount", UnselectedIcon = "ShieldAccountOutline"}
            };
        }
    }
}
