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
	public partial class CustomRoundedButtonWithImage : UserControl
	{
		public bool isSelected = false;

		public Brush BackgroundColor
		{
			get { return (Brush)GetValue(BackgroundColorProperty); }
			set { SetValue(BackgroundColorProperty, value); }
		}

		public Brush HoverColor
		{
			get { return (Brush)GetValue(HoverColorProperty); }
			set { SetValue(HoverColorProperty, value); }
		}

		public BitmapImage ImageSource
		{
			get { return (BitmapImage)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}


		public Thickness EllipsePadding
		{
			get { return (Thickness)GetValue(EllipsePaddingProperty); }
			set { SetValue(EllipsePaddingProperty, value); }
		}

		public static readonly DependencyProperty HoverColorProperty = DependencyProperty.Register("HoverColor", typeof(Brush), typeof(CustomRoundedButtonWithImage), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));
		public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(CustomRoundedButtonWithImage), new PropertyMetadata(new SolidColorBrush(Colors.Red)));
		public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(CustomRoundedButtonWithImage));
		public static readonly DependencyProperty EllipsePaddingProperty = DependencyProperty.Register("EllipsePadding", typeof(Thickness), typeof(CustomRoundedButtonWithImage), new PropertyMetadata(new Thickness(20)));


		public CustomRoundedButtonWithImage()
		{
			InitializeComponent();
		}
	}
}
