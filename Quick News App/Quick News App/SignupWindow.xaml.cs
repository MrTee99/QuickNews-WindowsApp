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
using System.Windows.Shapes;

namespace Quick_News_App
{
	public partial class SignupWindow : Window
	{
		public delegate void EventDelegate_OnSignUpPressed_GetSignUpInfo(string LoggedInUsername);
		public delegate void EventDelegate_OnSignUpWindowClosed_RemoveBlur();

		public event EventDelegate_OnSignUpPressed_GetSignUpInfo OnSignupPressed;
		public event EventDelegate_OnSignUpWindowClosed_RemoveBlur OnSignupWindowClosed;

		#region Singleton Initialization

		private static SignupWindow singleton = null;
		public static SignupWindow Singleton
		{
			get
			{
				if (singleton == null)
				{
					singleton = new SignupWindow();
				}
				return singleton;
			}
		}

		#endregion

		public SignupWindow()
		{
			InitializeComponent();
		}

		private void btn_Exit_Click(object sender, RoutedEventArgs e) => CloseSignupScreen();
		private void DragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

		private void btn_Signup_Click(object sender, RoutedEventArgs e)
		{
			var username = input_SignupUsername.Text;
			var email = input_SignupEmail.Text;
			var password = input_SignupPassword.PasswordInput.Password;
			
			if (username == "" || email == "" || password == "")
			{
				MessageBox.Show("Invalid Username, Email or Password", "Signup Failed", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
			{
				// Perform Signup here and then login user as well
				OnSignupPressed?.Invoke(username);
				CloseSignupScreen();
			}
		}

		#region Utility Methods

		private void CloseSignupScreen()
		{
			Hide();
			OnSignupWindowClosed?.Invoke();
			input_SignupUsername.Text = "";
			input_SignupEmail.Text = "";
			input_SignupPassword.PasswordInput.Password = "";
		}

		#endregion
	}
}
