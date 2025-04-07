using System;
using System.Windows;
using System.Windows.Controls;

namespace ebsiC.Assets.MVVM.View.userControl
{
    public partial class CustomPasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordBox), new PropertyMetadata(string.Empty));

        public CustomPasswordBox()
        {
            InitializeComponent();
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = ((PasswordBox)sender).Password;
        }
    }
}
