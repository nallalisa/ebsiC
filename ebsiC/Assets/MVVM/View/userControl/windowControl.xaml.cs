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
    public partial class windowControl : UserControl
    {

        private Window parentWindow;
        public windowControl()
        {
            InitializeComponent();
            this.Loaded += WindowControl_Loaded;
        }

        private void WindowControl_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = Window.GetWindow(this);
        }

        private void window_Minimize(object sender, RoutedEventArgs e) {
            if (parentWindow != null) { 
                parentWindow.WindowState = WindowState.Minimized;
            }
        }
        private void window_Maximize(object sender, RoutedEventArgs e) { 
            
            if (parentWindow.WindowState == WindowState.Normal) { 
                parentWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                parentWindow.WindowState = WindowState.Normal;
            }
        }
        private void window_Close(object sender, RoutedEventArgs e) {
            if (parentWindow != null) { 
                parentWindow.Close();
            }
        }
    }
}

