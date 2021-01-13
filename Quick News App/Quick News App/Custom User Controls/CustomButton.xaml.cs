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

namespace Quick_News_App.Custom_User_Controls
{
	public partial class CustomButton : UserControl
	{
		public string CusBtn_Content
		{
			get { return (string)GetValue(CusBtn_ContentProperty); }
			set { SetValue(CusBtn_ContentProperty, value); }
		}

		public Brush CusBtn_Hover
		{
			get { return (Brush)GetValue(CusBtn_HoverProperty); }
			set { SetValue(CusBtn_HoverProperty, value); }
		}
		public Brush CusBtn_Background
		{
			get { return (Brush)GetValue(CusBtn_BackgroundProperty); }
			set { SetValue(CusBtn_BackgroundProperty, value); }
		}
		public Brush CusBtn_Foreground
		{
			get { return (Brush)GetValue(CusBtn_ForegroundProperty); }
			set { SetValue(CusBtn_ForegroundProperty, value); }
		}

		public CornerRadius CusBtn_CornerRadius
		{
			get { return (CornerRadius)GetValue(CusBtn_CornerRadiusProperty); }
			set { SetValue(CusBtn_CornerRadiusProperty, value); }
		}
		public Thickness CusBtn_Margin
		{
			get { return (Thickness)GetValue(CusBtn_MarginProperty); }
			set { SetValue(CusBtn_MarginProperty, value); }
		}
		public Thickness CusBtn_Padding
		{
			get { return (Thickness)GetValue(CusBtn_PaddingProperty); }
			set { SetValue(CusBtn_PaddingProperty, value); }
		}


		public static readonly DependencyProperty CusBtn_ContentProperty = DependencyProperty.Register("CusBtn_Content", typeof(string), typeof(CustomButton), new PropertyMetadata("Custom Button"));

		public static readonly DependencyProperty CusBtn_HoverProperty = DependencyProperty.Register("CusBtn_Hover", typeof(Brush), typeof(CustomButton), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));
		public static readonly DependencyProperty CusBtn_BackgroundProperty = DependencyProperty.Register("CusBtn_Background", typeof(Brush), typeof(CustomButton), new PropertyMetadata(new SolidColorBrush(Colors.Cyan)));
		public static readonly DependencyProperty CusBtn_ForegroundProperty = DependencyProperty.Register("CusBtn_Foreground", typeof(Brush), typeof(CustomButton), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));

		public static readonly DependencyProperty CusBtn_CornerRadiusProperty = DependencyProperty.Register("CusBtn_CornerRadius", typeof(CornerRadius), typeof(CustomButton), new PropertyMetadata(new CornerRadius(0.0, 0.0, 0.0, 0.0)));
		public static readonly DependencyProperty CusBtn_MarginProperty = DependencyProperty.Register("CusBtn_Margin", typeof(Thickness), typeof(CustomButton), new PropertyMetadata(new Thickness(0, 0, 0, 0)));
		public static readonly DependencyProperty CusBtn_PaddingProperty = DependencyProperty.Register("CusBtn_Padding", typeof(Thickness), typeof(CustomButton), new PropertyMetadata(new Thickness(0, 0, 0, 0)));



		public CustomButton()
		{
			InitializeComponent();
		}

		public event RoutedEventHandler Click
		{
			add { cusBtn.Click += value; }
			remove { cusBtn.Click -= value; }
		}
	}
}
