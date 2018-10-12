using System;
using System.Collections.Generic;
using System.IO;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapSource CurBitMap;
        public MainWindow()
        {
            InitializeComponent();

            ImageDealer.OnCutImaging += OnCutImaging;
            //ImageDealer.BitSource = ImageHandler.GeBitmapImage(@"C:\Users\watrix\Pictures\Saved Pictures\家居.jpg");
        }

        private void OnCutImaging(object o, RoutedEventArgs source)
        {  
            if (source != null && source.GetType() == typeof(RoutedEventArgs))
            {
                // if (((RoutedEventArgs)source).OriginalSource.GetType() == typeof(CroppedBitmap))  
                {
                    CurBitMap = (BitmapSource)((RoutedEventArgs)source).OriginalSource;
                }

                if (CurBitMap != null) cutOverImg.Source = CurBitMap;
            }
        }

        /// <summary>  
        /// 保存头像  
        /// </summary>  
        public void btnCutPicture_Click()
        {
            string strFilePath = "D:\\2.png";

            var isSucc = ImageHandler.SaveBitmapSourceToLocalPath(this.CurBitMap, strFilePath);
            if (isSucc) { }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ImageDealer.BitSource = ImageHandler.GeBitmapImage(@"C:\Users\watrix\Pictures\Saved Pictures\家居.jpg");
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            btnCutPicture_Click();
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            ImageDealer.CutImage();
        }
    }
}
