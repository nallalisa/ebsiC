using ebsiC.Assets.MVVM.View.userControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebsiC.Assets.MVVM.ViewModel
{
    public class TabsVM
    {
        public ObservableCollection<TabItemModel> adminTabs { get; set; }
        public ObservableCollection<TabItemModel> employeeForm { get; set; }
        public int CurrentIndex { get; set; }
        public TabsVM()
        {
            adminTabs = new ObservableCollection<TabItemModel>
            {
                new TabItemModel { Header = "Admin", Content = new adminTabView() },
                new TabItemModel { Header = "Employee", Content = new empTabView() },
            };

            CurrentIndex = 0;
        }
    }
}
