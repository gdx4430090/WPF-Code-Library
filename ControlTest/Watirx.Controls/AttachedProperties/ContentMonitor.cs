using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Watirx.Controls.AttachedProperties
{
    public class ContentMonitor : DependencyObject
    {
        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(ContentMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));



        public static int GetContentLength(DependencyObject obj)
        {
            return (int)obj.GetValue(ContentLengthProperty);
        }

        public static void SetContentLength(DependencyObject obj, int value)
        {
            obj.SetValue(ContentLengthProperty, value);
        }

        public static readonly DependencyProperty ContentLengthProperty =
            DependencyProperty.RegisterAttached("ContentLength", typeof(int), typeof(ContentMonitor), new UIPropertyMetadata(0));

        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (typeof(PasswordBox).IsInstanceOfType(d))
            {
                var pb = d as PasswordBox;
                if (pb != null)
                {
                    if ((bool)e.NewValue)
                        pb.PasswordChanged += ContentChanged;
                    else
                        pb.PasswordChanged -= ContentChanged;
                }
            }
            else if (typeof(CTextBox).IsInstanceOfType(d))
            {
                var tb = d as CTextBox;
                if (tb != null)
                {
                    if ((bool)e.NewValue)
                        tb.TextChanged += ContentChanged;
                }
            }
        }

        static void ContentChanged(object sender, RoutedEventArgs e)
        {
            if (typeof(PasswordBox).IsInstanceOfType(sender))
            {
                var pb = sender as PasswordBox;
                if (pb != null)
                    SetContentLength(pb, pb.Password.Length);
            }
            else if (typeof(CTextBox).IsInstanceOfType(sender))
            {
                var tb = sender as CTextBox;
                if (tb != null)
                    SetContentLength(tb, tb.Text.Length);
            }
        }
    }
}
