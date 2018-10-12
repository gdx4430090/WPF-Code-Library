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
    ///     <MyNamespace:CIconButton/>
    ///
    /// </summary>
    public class CIconButton : CButton
    {
        static CIconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CIconButton), new FrameworkPropertyMetadata(typeof(CIconButton)));
        }

        //#region CornerRadius
        //public static readonly DependencyProperty CornerRadiusProperty =
        //    DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CIconButton), new PropertyMetadata(new CornerRadius(2)));
        ///// <summary>
        ///// 按钮圆角大小,左上，右上，右下，左下
        ///// </summary>
        //public CornerRadius CornerRadius
        //{
        //    get { return (CornerRadius)GetValue(CornerRadiusProperty); }
        //    set { SetValue(CornerRadiusProperty, value); }
        //}

        //#endregion

        //#region PressedBackground
        //public static readonly DependencyProperty PressedBackgroundProperty =
        //    DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(CIconButton), new PropertyMetadata(Brushes.DarkBlue));
        ///// <summary>
        ///// 鼠标按下背景样式
        ///// </summary>
        //public Brush PressedBackground
        //{
        //    get { return (Brush)GetValue(PressedBackgroundProperty); }
        //    set { SetValue(PressedBackgroundProperty, value); }
        //}
        //#endregion

        //#region  PressedForeground
        //public static readonly DependencyProperty PressedForegroundProperty =
        //    DependencyProperty.Register("PressedForeground", typeof(Brush), typeof(CIconButton), new PropertyMetadata(Brushes.White));
        ///// <summary>
        ///// 鼠标按下前景样式（图标、文字）
        ///// </summary>
        //public Brush PressedForeground
        //{
        //    get { return (Brush)GetValue(PressedForegroundProperty); }
        //    set { SetValue(PressedForegroundProperty, value); }
        //}

        //#endregion

        //#region MouseOverBackground
        //public static readonly DependencyProperty MouseOverBackgroundProperty =
        //    DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(CIconButton), new PropertyMetadata(Brushes.RoyalBlue));
        ///// <summary>
        ///// 鼠标进入背景样式
        ///// </summary>
        //public Brush MouseOverBackground
        //{
        //    get { return (Brush)GetValue(MouseOverBackgroundProperty); }
        //    set { SetValue(MouseOverBackgroundProperty, value); }
        //}

        //#endregion

        //#region MouseOverForeground
        //public static readonly DependencyProperty MouseOverForegroundProperty =
        //    DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(CIconButton), new PropertyMetadata(Brushes.White));
        ///// <summary>
        ///// 鼠标进入前景样式
        ///// </summary>
        //public Brush MouseOverForeground
        //{
        //    get { return (Brush)GetValue(MouseOverForegroundProperty); }
        //    set { SetValue(MouseOverForegroundProperty, value); }
        //}
        //#endregion

        #region FIcon
        public static readonly DependencyProperty FIconProperty =
            DependencyProperty.Register("FIcon", typeof(string), typeof(CIconButton), new PropertyMetadata("\ue604"));
        /// <summary>
        /// 按钮字体图标编码
        /// </summary>
        public string FIcon
        {
            get { return (string)GetValue(FIconProperty); }
            set { SetValue(FIconProperty, value); }
        }
        #endregion

        #region FIconSize
        public static readonly DependencyProperty FIconSizeProperty =
            DependencyProperty.Register("FIconSize", typeof(int), typeof(CIconButton), new PropertyMetadata(20));
        /// <summary>
        /// 按钮字体图标大小
        /// </summary>
        public int FIconSize
        {
            get { return (int)GetValue(FIconSizeProperty); }
            set { SetValue(FIconSizeProperty, value); }
        }
        #endregion

        #region FIconMargin
        public static readonly DependencyProperty FIconMarginProperty = DependencyProperty.Register(
            "FIconMargin", typeof(Thickness), typeof(CIconButton), new PropertyMetadata(new Thickness(0, 1, 3, 1)));
        /// <summary>
        /// 字体图标间距
        /// </summary>
        public Thickness FIconMargin
        {
            get { return (Thickness)GetValue(FIconMarginProperty); }
            set { SetValue(FIconMarginProperty, value); }
        }

        #endregion

        #region AllowsAnimation
        public static readonly DependencyProperty AllowsAnimationProperty = DependencyProperty.Register(
            "AllowsAnimation", typeof(bool), typeof(CIconButton), new PropertyMetadata(true));
        /// <summary>
        /// 是否启用Ficon动画
        /// </summary>
        public bool AllowsAnimation
        {
            get { return (bool)GetValue(AllowsAnimationProperty); }
            set { SetValue(AllowsAnimationProperty, value); }
        }

        #endregion

        #region ContentDecorations
        public static readonly DependencyProperty ContentDecorationsProperty = DependencyProperty.Register(
            "ContentDecorations", typeof(TextDecorationCollection), typeof(CIconButton), new PropertyMetadata(null));
        public TextDecorationCollection ContentDecorations
        {
            get { return (TextDecorationCollection)GetValue(ContentDecorationsProperty); }
            set { SetValue(ContentDecorationsProperty, value); }
        }
        #endregion

        #region Orientation

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation", typeof(Orientation), typeof(CIconButton), new PropertyMetadata(Orientation.Vertical));

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        #endregion
    }
}
