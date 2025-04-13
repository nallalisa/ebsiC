using ebsiC.Assets.MVVM.View.admin;
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
    /// <summary>
    /// Interaction logic for adminTabView.xaml
    /// </summary>
    public partial class adminTabView : UserControl
    {
        public adminTabView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var modal = new NewEmployeeForm();
            modal.Owner = Window.GetWindow(this);
            modal.ShowDialog();
        }

    }
}
