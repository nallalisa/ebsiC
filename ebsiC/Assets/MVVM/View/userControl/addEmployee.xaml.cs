using ebsiC.Assets.Classes;
using ebsiC.Assets.MVVM.Model;
using ebsiC.Assets.MVVM.ViewModel;
using ICSharpCode.SharpZipLib.Zip;
using MaterialDesignThemes.Wpf;
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
    public partial class addEmployee : UserControl
    {
        public addEmployee()
        {
            InitializeComponent();

            this.DataContext = new addEmployeeVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeTabControl.SelectedIndex < EmployeeTabControl.Items.Count - 1)
            {
                EmployeeTabControl.SelectedIndex++;

                if (EmployeeTabControl.SelectedIndex == EmployeeTabControl.Items.Count - 1)
                {
                    NextButton.Content = "Submit";
                }
            }
            else
            {
                MessageBox.Show("Form submitted!");
                EmployeeTabControl.SelectedIndex = 0;
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (EmployeeTabControl.SelectedIndex > 0)
            {
                EmployeeTabControl.SelectedIndex--;

                if (EmployeeTabControl.SelectedIndex < EmployeeTabControl.Items.Count - 1)
                {
                    NextButton.Content = "Next";
                }
            }
        }
    }
}
