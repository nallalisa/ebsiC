using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ebsiC.Assets.MVVM.View.userControl
{
    /// <summary>
    /// Interaction logic for addEmployee.xaml
    /// </summary>
    public partial class addEmployee : UserControl
    {
        public addEmployee()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeTabControl.SelectedIndex < EmployeeTabControl.Items.Count - 1)
                EmployeeTabControl.SelectedIndex++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (EmployeeTabControl.SelectedIndex > 0)
                EmployeeTabControl.SelectedIndex--;
        }
    }
}
