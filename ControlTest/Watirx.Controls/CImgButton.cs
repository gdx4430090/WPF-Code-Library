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

namespace Watirx.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:Watirx.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:Watirx.Controls;assembly=Watirx.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:CImgButton/>
    ///
    /// </summary>
    //[TemplatePart(Name = "PART_ImageSource", Type = typeof(Image))]
    public class CImgButton : CButton
    {
        static CImgButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CImgButton), new FrameworkPropertyMetadata(typeof(CImgButton)));
        }

        #region  ImageSource
        public static readonly DependencyProperty ImageSourceProperty = 
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CImgButton), new PropertyMetadata(null));
        /// <summary>
        /// 默认图片
        /// </summary>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        #endregion

        #region PressedImageSource
        public static readonly DependencyProperty PressedImageSourceProperty = 
            DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(CImgButton), new PropertyMetadata(null));
        /// <summary>
        /// 鼠标按下图片
        /// </summary>
        public ImageSource PressedImageSource
        {
            get { return (ImageSource)GetValue(PressedImageSourceProperty); }
            set { SetValue(PressedImageSourceProperty, value); }
        }

        #endregion

        #region MouseMoveImageSource
        public static readonly DependencyProperty MouseMoveImageSourceProperty = 
            DependencyProperty.Register("MouseMoveImageSource", typeof(ImageSource), typeof(CImgButton), new PropertyMetadata(null));
        /// <summary>
        /// 鼠标划过图片
        /// </summary>
        public ImageSource MouseMoveImageSource
        {
            get { return (ImageSource)GetValue(MouseMoveImageSourceProperty); }
            set { SetValue(MouseMoveImageSourceProperty, value); }
        }

        #endregion

        #region DisabledImageSource
        public static readonly DependencyProperty DisabledImageSourceProperty = 
            DependencyProperty.Register("DisabledImageSource", typeof(ImageSource), typeof(CImgButton), new PropertyMetadata(null));
        /// <summary>
        /// 禁用图片
        /// </summary>
        public ImageSource DisabledImageSource
        {
            get { return (ImageSource)GetValue(DisabledImageSourceProperty); }
            set { SetValue(DisabledImageSourceProperty, value); }
        }

        #endregion

        #region Orientation
        public static readonly DependencyProperty OrientationProperty = 
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(CImgButton), new PropertyMetadata(Orientation.Vertical));
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        
        #endregion

        #region FImageSize
        public static readonly DependencyProperty FImageSizeProperty =
            DependencyProperty.Register("FImageSize", typeof(int), typeof(CImgButton), new PropertyMetadata(30));
        /// <summary>
        /// 图片大小
        /// </summary>
        public int FImageSize
        {
            get { return (int)GetValue(FImageSizeProperty); }
            set { SetValue(FImageSizeProperty, value); }
        }
        #endregion

        #region FImageMargin
        public static readonly DependencyProperty FImageMarginProperty = DependencyProperty.Register(
            "FImageMargin", typeof(Thickness), typeof(CImgButton), new PropertyMetadata(new Thickness(5, 5, 5, 5)));
        /// <summary>
        /// 图片间距
        /// </summary>
        public Thickness FImageMargin
        {
            get { return (Thickness)GetValue(FImageMarginProperty); }
            set { SetValue(FImageMarginProperty, value); }
        }

        #endregion
    }
}
