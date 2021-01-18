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
		private QuickNewsDatabaseDataContext _db;

		public delegate void EventDelegate_OnLoginPressed_GetLoginInfo(bool isLoggedIn, bool isAdminLoggedIn, string LoggedInUsername, int LoggedInUserID);
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
			_db = new QuickNewsDatabaseDataContext();
		}

		private void btn_Exit_Click(object sender, RoutedEventArgs e) => CloseLoginScreen();

		private void DragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

		private void btn_Login_Click(object sender, RoutedEventArgs e)
		{
			bool isLoggedIn = false;
			bool isAdminLoggedIn = false;
			string LoggedInUsername = "";

			var username = input_LoginUsername.Text.Trim();
			var password = input_LoginPassword.Password;

			var doesUserExists = _db.UserTables.FirstOrDefault(q => q.Username == username && q.Password == password);

			if (doesUserExists != null)
			{
				isLoggedIn = true;
				isAdminLoggedIn = doesUserExists.isAdmin;
				LoggedInUsername = username;

				OnLoginPressed?.Invoke(isLoggedIn, isAdminLoggedIn, LoggedInUsername, doesUserExists.User_ID);
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
			input_LoginPassword.Password = "";
		}

		#endregion

		private void input_LoginPassword_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if(input_LoginPassword.Password.Length == 0)
				txt_passPlaceholder.Visibility = Visibility.Visible;
			else
				txt_passPlaceholder.Visibility = Visibility.Hidden;
		}


	}
}
