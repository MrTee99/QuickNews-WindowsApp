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
	/// Interaction logic for CustomTextBoxWithPlaceholder.xaml
	/// </summary>
	public partial class CustomTextBoxWithPlaceholder : UserControl
	{

		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}
		public Thickness CusTextBox_PaddingInsideOfTextBox
		{
			get { return (Thickness)GetValue(CusTextBox_PaddingInsideOfTextBoxProperty); }
			set { SetValue(CusTextBox_PaddingInsideOfTextBoxProperty, value); }
		}
		public Thickness cusTextBox_PaddingOfContainer
		{
			get { return (Thickness)GetValue(cusTextBox_PaddingOfContainerProperty); }
			set { SetValue(cusTextBox_PaddingOfContainerProperty, value); }
		}

		public Brush PlaceholderColor
		{
			get { return (Brush)GetValue(PlaceholderColorProperty); }
			set { SetValue(PlaceholderColorProperty, value); }
		}
		public string Placeholder
		{
			get { return (string)GetValue(PlaceholderProperty); }
			set { SetValue(PlaceholderProperty, value); }
		}
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public Brush ForegroundNormal
		{
			get { return (Brush)GetValue(ForegroundNormalProperty); }
			set { SetValue(ForegroundNormalProperty, value); }
		}
		public Brush BackgroundNormal
		{
			get { return (Brush)GetValue(BackgroundNormalProperty); }
			set { SetValue(BackgroundNormalProperty, value); }
		}
		public Brush OutlineNormal
		{
			get { return (Brush)GetValue(OutlineNormalProperty); }
			set { SetValue(OutlineNormalProperty, value); }
		}


		public bool IsPassword
		{
			get { return (bool)GetValue(IsPasswordProperty); }
			set { SetValue(IsPasswordProperty, value); }
		}
		public int cusTextBox_BorderThickness
		{
			get { return (int)GetValue(cusTextBox_BorderThicknessProperty); }
			set { SetValue(cusTextBox_BorderThicknessProperty, value); }
		}



		public TextWrapping cusTextBox_TextWrap
		{
			get { return (TextWrapping)GetValue(cusTextBox_TextWrapProperty); }
			set { SetValue(cusTextBox_TextWrapProperty, value); }
		}
		public bool cusTextBox_AcceptsReturn
		{
			get { return (bool)GetValue(cusTextBox_AcceptsReturnProperty); }
			set { SetValue(cusTextBox_AcceptsReturnProperty, value); }
		}
		public int cusTextBox_MaxLength
		{
			get { return (int)GetValue(cusTextBox_MaxLengthProperty); }
			set { SetValue(cusTextBox_MaxLengthProperty, value); }
		}




		public static readonly DependencyProperty cusTextBox_MaxLengthProperty = DependencyProperty.Register("cusTextBox_MaxLength", typeof(int), typeof(CustomTextBoxWithPlaceholder));
		public static readonly DependencyProperty cusTextBox_AcceptsReturnProperty = DependencyProperty.Register("cusTextBox_AcceptsReturn", typeof(bool), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(false));
		public static readonly DependencyProperty cusTextBox_TextWrapProperty = DependencyProperty.Register("cusTextBox_TextWrap", typeof(TextWrapping), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(TextWrapping.NoWrap));

		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(new CornerRadius(0.0, 0.0, 0.0, 0.0)));
		public static readonly DependencyProperty CusTextBox_PaddingInsideOfTextBoxProperty = DependencyProperty.Register("CusTextBox_PaddingInsideOfTextBox", typeof(Thickness), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(new Thickness(0, 0, 0, 0)));
		public static readonly DependencyProperty cusTextBox_PaddingOfContainerProperty = DependencyProperty.Register("cusTextBox_PaddingOfContainer", typeof(Thickness), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(new Thickness(0, 0, 0, 0)));


		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CustomTextBoxWithPlaceholder));
		public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register("Placeholder", typeof(string), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata("Placeholder"));
		public static readonly DependencyProperty PlaceholderColorProperty = DependencyProperty.Register("PlaceholderColor", typeof(Brush), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#393E46"))));

		public static readonly DependencyProperty ForegroundNormalProperty = DependencyProperty.Register("ForegroundNormal", typeof(Brush), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
		public static readonly DependencyProperty BackgroundNormalProperty = DependencyProperty.Register("BackgroundNormal", typeof(Brush), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(new SolidColorBrush(Colors.White)));
		public static readonly DependencyProperty OutlineNormalProperty = DependencyProperty.Register("OutlineNormal", typeof(Brush), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
	
		public static readonly DependencyProperty IsPasswordProperty = DependencyProperty.Register("IsPassword", typeof(bool), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(false));
		public static readonly DependencyProperty cusTextBox_BorderThicknessProperty = DependencyProperty.Register("cusTextBox_BorderThickness", typeof(int), typeof(CustomTextBoxWithPlaceholder), new PropertyMetadata(1));



		public CustomTextBoxWithPlaceholder()
		{
			InitializeComponent();
		}

		private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
		{
			Input.Text = PasswordInput.Password;
		}
	}
}
