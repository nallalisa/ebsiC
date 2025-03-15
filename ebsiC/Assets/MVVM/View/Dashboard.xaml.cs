using ebsiC.Assets.MVVM.ViewModel;
using System.Windows;

namespace ebsiC.Assets.MVVM.View
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardVM();
        }
    }
}
