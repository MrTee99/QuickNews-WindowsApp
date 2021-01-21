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
		private QuickNewsDatabaseDataContext _db;

		public delegate void EventDelegate_OnSignUpPressed_GetSignUpInfo(string LoggedInUsername, int LoggedInUserID);
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
			_db = new QuickNewsDatabaseDataContext();
		}

		private void btn_Exit_Click(object sender, RoutedEventArgs e) => CloseSignupScreen();
		private void DragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

		private void btn_Signup_Click(object sender, RoutedEventArgs e)
		{
			var username = input_SignupUsername.Text.Trim();
			var email = input_SignupEmail.Text.Trim();
			var password = input_SignupPassword.Password;

			var usernameTaken = _db.UserTables.FirstOrDefault(q => q.Username == username);
			var alreadyRegisteredWithThisEmail = _db.UserTables.FirstOrDefault(q => q.Email == email);

			if (username == "" || email == "" || password == "" || usernameTaken != null || alreadyRegisteredWithThisEmail != null)
			{
				string usernameErrorMessage = "User with this Username already exists. Kindly opt for new username.";
				string emailErrorMessage = "User is already registered with this Email.";
				string defaultMessage = "Invalid Username, Email or Password.";

				string message = (usernameTaken != null) ? usernameErrorMessage : (alreadyRegisteredWithThisEmail != null) ? emailErrorMessage : defaultMessage;

				MessageBox.Show(message, "Signup Failed", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
			{
				UserTable newUser = new UserTable();
				newUser.Username = username;
				newUser.Email = email;
				newUser.Password = password;
				newUser.isAdmin = false;
				_db.UserTables.InsertOnSubmit(newUser);
				_db.SubmitChanges();

				int userID = (from user in _db.UserTables where user.Username == username select user.User_ID).FirstOrDefault();

				// Perform Signup here and then login user as well
				OnSignupPressed?.Invoke(username, userID);
				CloseSignupScreen();

				MessageBox.Show("Congratulations " + username + "! you have Successfully Signed Up", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		#region Utility Methods

		private void CloseSignupScreen()
		{
			Hide();
			OnSignupWindowClosed?.Invoke();
			input_SignupUsername.Text = "";
			input_SignupEmail.Text = "";
			input_SignupPassword.Password = "";
		}

		#endregion

		private void input_SignupPassword_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (input_SignupPassword.Password.Length == 0)
				txt_passPlaceholder.Visibility = Visibility.Visible;
			else
				txt_passPlaceholder.Visibility = Visibility.Hidden;
		}
	}
}
