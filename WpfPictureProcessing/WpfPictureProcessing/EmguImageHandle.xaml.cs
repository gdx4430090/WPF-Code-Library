using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

namespace WpfPictureProcessing
{
    /// <summary>
    /// EmguImageHandle.xaml 的交互逻辑
    /// </summary>
    public partial class EmguImageHandle : Window
    {
        public EmguImageHandle()
        {
            InitializeComponent();
            this.Loaded += EmguImageHandle_Loaded;
        }

        private void EmguImageHandle_Loaded(object sender, RoutedEventArgs e)
        {
            Mat img = CvInvoke.Imread(@"001.jpg", Emgu.CV.CvEnum.ImreadModes.Color);

            Bitmap bitmap = new Bitmap(@"001.jpg"); //.net创建图片
            Image<Bgr, byte> image = new Image<Bgr, byte>(@"001.jpg"); //创建图片

            Mat mat = new Mat(@"001.jpg"); //创建图片



            //CvInvoke.PutText(img, "Some Things", new System.Drawing.Point(5, 350), FontFace.HersheyComplex, 2.0, new Bgr(Color.Blue).MCvScalar);

            //img1.Source = new BitmapImage(new Uri(@"001.jpg", UriKind.RelativeOrAbsolute));
            //img2.Source = BitmapSourceConvert.ToBitmapSource(image);
            //img3.Source = BitmapSourceConvert.ToBitmapSource(img);

            CvInvoke.Rectangle(img, new Rectangle(5, 5, 600, 300), new Bgr(System.Drawing.Color.Red).MCvScalar, 3);

            var _image = img.ToImage<Bgr, byte>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            PaintText(_image, "测试",new Point(310,5),Brushes.Blue);
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);

            BitmapSource bs = Imaging.CreateBitmapSourceFromHBitmap(_image.ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            img4.Source = bs;
            
            //Rectangle rectangle = new Rectangle(10, 20, 30, 40);
            //Image<Gray, byte> Sub = Image.GetSubRect(rectangle);
            //Image<Gray, byte> CropImage = new Image<Gray, byte>(Sub.Size);
            //CvInvoke.cvCopy(Sub, CropImage, IntPtr.Zero);

        }

        private void PaintText(Image<Bgr, Byte> image,string text,Point point,Brush color)
        {
            var bmp = new System.Drawing.Bitmap(200, 45);
            Graphics g = Graphics.FromImage(bmp);
            Font drawFont = new Font(System.Drawing.FontFamily.GenericSerif, 20, System.Drawing.FontStyle.Bold);
            g.DrawString(text, drawFont, color, new PointF(0, 0));
            g.Save();

            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 45; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    if (c.R > 0 || c.B > 0 || c.G > 0)
                    {
                        CvInvoke.cvSet2D(image, j + point.X, i + point.Y, new MCvScalar(c.B, c.G, c.R)); //修改对应像素值
                    }
                }
            }
        }
    }
}
