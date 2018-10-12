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

namespace WpfPictureProcessing
{
    /// <summary>
    /// ImageEx.xaml 的交互逻辑
    /// </summary>
    public partial class ImageEx : Window
    {
        //private bool isMouseLeftButtonDown = false;
        //Point previousMousePoint = new Point(0, 0);

        public ImageEx()
        {
            InitializeComponent();
        }

        //private void img_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    isMouseLeftButtonDown = true;
        //    previousMousePoint = e.GetPosition(img);
        //}

        //private void img_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    isMouseLeftButtonDown = false;
        //}

        //private void img_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    isMouseLeftButtonDown = false;
        //}

        //private void img_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isMouseLeftButtonDown == true)
        //    {
        //        Point position = e.GetPosition(img);
        //        tlt.X += position.X - this.previousMousePoint.X;
        //        tlt.Y += position.Y - this.previousMousePoint.Y;
        //    }
        //}

        //private void img_MouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    Point centerPoint = e.GetPosition(img);

        //    double val = (double)e.Delta / 2000;   //描述鼠标滑轮滚动
        //    if (sfr.ScaleX < 0.3 && sfr.ScaleY < 0.3 && e.Delta < 0)
        //    {
        //        return;
        //    }
        //    sfr.CenterX = centerPoint.X;
        //    sfr.CenterY = centerPoint.Y;

        //    sfr.ScaleX += val;
        //    sfr.ScaleY += val;
        //}
        private bool mouseDown;
        private Point mouseXY;

        private void IMG1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            img.CaptureMouse();
            mouseDown = true;
            mouseXY = e.GetPosition(img);
        }
        private void IMG1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            img.ReleaseMouseCapture();
            mouseDown = false;
        }
        private void IMG1_MouseMove(object sender, MouseEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            if (mouseDown)
            {
                Domousemove(img, e);
            }
        }
        private void Domousemove(ContentControl img, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }
            var group = IMG.FindResource("Imageview") as TransformGroup;
            var transform = group.Children[1] as TranslateTransform;
            var position = e.GetPosition(img);
            transform.X -= mouseXY.X - position.X;
            transform.Y -= mouseXY.Y - position.Y;
            mouseXY = position;
        }
        private void IMG1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var img = sender as ContentControl;
            if (img == null)
            {
                return;
            }
            var point = e.GetPosition(img);
            var group = IMG.FindResource("Imageview") as TransformGroup;
            var delta = e.Delta * 0.001;
            DowheelZoom(group, point, delta);
        }
        private void DowheelZoom(TransformGroup group, Point point, double delta)
        {
            var pointToContent = group.Inverse.Transform(point);
            var transform = group.Children[0] as ScaleTransform;
            if (transform.ScaleX + delta < 0.1) return;
            transform.ScaleX += delta;
            transform.ScaleY += delta;
            var transform1 = group.Children[1] as TranslateTransform;
            transform1.X = -1 * ((pointToContent.X * transform.ScaleX) - point.X);
            transform1.Y = -1 * ((pointToContent.Y * transform.ScaleY) - point.Y);
        }

        //private void DowheelZoom(TransformGroup group, Point point, double delta)
        //{
        //    var transform = group.Children[0] as ScaleTransform;
        //    if (transform.ScaleX + delta < 0.1) return;
        //    transform.CenterX = point1.X - 1;
        //    transform.CenterY = point1.Y - 1;
        //    transform.ScaleX += delta;
        //    transform.ScaleY += delta;
        //}
    }
}
