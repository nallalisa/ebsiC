﻿using System;
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
    public partial class textBox : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(textBox), new PropertyMetadata(string.Empty));
        public textBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
