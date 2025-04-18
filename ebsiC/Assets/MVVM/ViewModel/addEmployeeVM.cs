using ebsiC.Assets.Classes;
using ebsiC.Assets.MVVM.Model;
using ebsiC.Assets.MVVM.View.userControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebsiC.Assets.MVVM.ViewModel
{
    public class addEmployeeVM : ObservableObject
    {
        public ObservableCollection<employeeTab> Tabs { get; set; }

        private Employee _employee = new();
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }

        public addEmployeeVM() {
            Tabs = new ObservableCollection<employeeTab>()
            {
                new employeeTab { Header = "PERSONAL INFORMATION", Content = new EmpFormPersonalInfo() },
                new employeeTab { Header = "ADDRESS", Content = new EmpFormPersonalInfo() },
                new employeeTab { Header = "EMPLOYEE INFORMATION", Content = new EmpFormPersonalInfo() },
                new employeeTab { Header = "GOVERNMENT INFORMATION", Content = new EmpFormPersonalInfo() }
            };
        }
    }
}
