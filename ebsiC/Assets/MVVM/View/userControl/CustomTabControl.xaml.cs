using ebsiC.Assets.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class CustomTabControl : UserControl
    {
        public CustomTabControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<TabItemModel> Tabs
        {
            get { return (ObservableCollection<TabItemModel>)GetValue(TabsProperty); }
            set { SetValue(TabsProperty, value); }
        }
        public static readonly DependencyProperty TabsProperty =
            DependencyProperty.Register("Tabs", typeof(ObservableCollection<TabItemModel>), typeof(CustomTabControl), new PropertyMetadata(null));

        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            set { SetValue(SelectedTabIndexProperty, value); }
        }

        public static readonly DependencyProperty SelectedTabIndexProperty =
            DependencyProperty.Register("SelectedTabIndex", typeof(int), typeof(CustomTabControl), new PropertyMetadata(0));
    }
    public class  TabItemModel
    {
        public string Header { get; set; }
        public object Content { get; set; }
    }
}
