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
	
	public partial class LoginWindow : Window
	{
		private string adminUsername = "ADMIN";
		private string adminPassword = "123";

		public delegate void EventDelegate_OnLoginPressed_GetLoginInfo(bool isLoggedIn, bool isAdminLoggedIn, string LoggedInUsername);
		public delegate void EventDelegate_OnLoginWindowClosed_RemoveBlur();

		public event EventDelegate_OnLoginPressed_GetLoginInfo OnLoginPressed;
		public event EventDelegate_OnLoginWindowClosed_RemoveBlur OnLoginWindowClosed;

		#region Singleton Initialization

		private static LoginWindow singleton = null;
		public static LoginWindow Singleton
		{
			get
			{
				if (singleton == null)
				{
					singleton = new LoginWindow();
				}
				return singleton;
			}
		}

		#endregion

		public LoginWindow()
		{
			InitializeComponent();
		}

		private void btn_Exit_Click(object sender, RoutedEventArgs e) => CloseLoginScreen();

		private void DragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

		private void btn_Login_Click(object sender, RoutedEventArgs e)
		{
			bool isLoggedIn = false;
			bool isAdminLoggedIn = false;
			string LoggedInUsername = "";

			var username = input_LoginUsername.Text;
			var password = input_LoginPassword.PasswordInput.Password;

			if (username == adminUsername && password == adminPassword)
			{
				isLoggedIn = true;
				isAdminLoggedIn = true;
				LoggedInUsername = adminUsername;

				OnLoginPressed?.Invoke(isLoggedIn, isAdminLoggedIn, LoggedInUsername);
				CloseLoginScreen();
			}
			else
			{
				MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		#region Utility Methods

		private void CloseLoginScreen()
		{
			Hide();
			OnLoginWindowClosed?.Invoke();
			input_LoginUsername.Text = "";
			input_LoginPassword.PasswordInput.Password = "";
		}

		#endregion
	}
}
