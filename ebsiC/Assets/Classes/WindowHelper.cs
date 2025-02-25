using System.Windows;
using System.Windows.Input;

namespace ebsiC.Assets.Classes
{
    public static class WindowHelper
    {
        // Attached Property: StartupLocation
        public static readonly DependencyProperty StartupLocationProperty =
            DependencyProperty.RegisterAttached(
                "StartupLocation",
                typeof(WindowStartupLocation),
                typeof(WindowHelper),
                new PropertyMetadata(WindowStartupLocation.Manual, OnStartupLocationChanged));

        public static WindowStartupLocation GetStartupLocation(DependencyObject obj)
        {
            return (WindowStartupLocation)obj.GetValue(StartupLocationProperty);
        }

        public static void SetStartupLocation(DependencyObject obj, WindowStartupLocation value)
        {
            obj.SetValue(StartupLocationProperty, value);
        }

        private static void OnStartupLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.WindowStartupLocation = (WindowStartupLocation)e.NewValue;
            }
        }

        // Attached Property: IsDraggable
        public static readonly DependencyProperty IsDraggableProperty =
            DependencyProperty.RegisterAttached(
                "IsDraggable",
                typeof(bool),
                typeof(WindowHelper),
                new PropertyMetadata(false, OnIsDraggableChanged));

        public static bool GetIsDraggable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDraggableProperty);
        }

        public static void SetIsDraggable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDraggableProperty, value);
        }

        private static void OnIsDraggableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                if ((bool)e.NewValue)
                {
                    // Attach MouseLeftButtonDown event for dragging
                    window.MouseLeftButtonDown += Window_MouseLeftButtonDown;
                }
                else
                {
                    // Detach MouseLeftButtonDown event
                    window.MouseLeftButtonDown -= Window_MouseLeftButtonDown;
                }
            }
        }

        private static void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Window window && e.LeftButton == MouseButtonState.Pressed)
            {
                try
                {
                    window.DragMove();
                }
                catch
                {
                    
                }
            }
        }
    }
}
