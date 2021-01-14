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
	/// <summary>
	/// Interaction logic for CustomButtonWithImage.xaml
	/// </summary>
	public partial class CustomButtonWithImage : UserControl
	{
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


		public Thickness ButtonPadding
		{
			get { return (Thickness)GetValue(ButtonPaddingProperty); }
			set { SetValue(ButtonPaddingProperty, value); }
		}


		public float CornerRadius
		{
			get { return (float)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		public static readonly DependencyProperty HoverColorProperty = DependencyProperty.Register("HoverColor", typeof(Brush), typeof(CustomButtonWithImage), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));
		public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(CustomButtonWithImage), new PropertyMetadata(new SolidColorBrush(Colors.Red)));
		public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(CustomButtonWithImage));
		public static readonly DependencyProperty ButtonPaddingProperty = DependencyProperty.Register("ButtonPadding", typeof(Thickness), typeof(CustomButtonWithImage), new PropertyMetadata(new Thickness(20)));
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(float), typeof(CustomButtonWithImage), new PropertyMetadata(0f));


		public CustomButtonWithImage()
		{
			InitializeComponent();
		}
	}
}
