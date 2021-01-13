using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Quick_News_App.Modules;
using Quick_News_App.Utils;

namespace Quick_News_App
{

	public partial class MainWindow : Window
	{
		private bool isLoggedIn = false;
		Utilities utilities = new Utilities();

		public MainWindow()
		{
			InitializeComponent();
			btn_ThemeSwitcher.InitializeToggleSwitch(true);

			utilities.UpdateLoginAndSignupButtonsUI(isLoggedIn, btn_LoginOrLogout, btn_Signup);
		}

		#region Title Bar Windows Buttons Functions

		private void DragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
		private void btn_Exit_Click(object sender, RoutedEventArgs e) => Close();
		private void btn_Minimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

		#endregion

		#region Login / Signup Button

		private void btn_LoginOrLogout_Click(object sender, RoutedEventArgs e) 
		{
			if (isLoggedIn == false)
			{
				LoginWindow login = new LoginWindow(MainGrid, this);
				login.ShowDialog();
			}
			else
			{
				// Perform logout functionality
				isLoggedIn = false;
				utilities.UpdateLoginAndSignupButtonsUI(isLoggedIn, btn_LoginOrLogout, btn_Signup);
			}
		}

		private void btn_Signup_Click(object sender, RoutedEventArgs e) 
		{
			SignupWindow signup = new SignupWindow(MainGrid, this);
			signup.ShowDialog();
		}

		#endregion

		#region Main Buttons

		private void btn_Bookmark_Click(object sender, RoutedEventArgs e) { }

		private void btn_ReadHistory_Click(object sender, RoutedEventArgs e) { }

		private void btn_MyFeed_Click(object sender, RoutedEventArgs e) { }

		#endregion

		#region Categories Buttons

		private void btn_cat_Politics_MouseDown(object sender, MouseButtonEventArgs e) { }

		private void btn_cat_Sport_MouseDown(object sender, MouseButtonEventArgs e) { }

		private void btn_cat_Business_MouseDown(object sender, MouseButtonEventArgs e) { }

		private void btn_cat_Science_MouseDown(object sender, MouseButtonEventArgs e) { }

		private void btn_cat_Automobile_MouseDown(object sender, MouseButtonEventArgs e) { }

		private void btn_cat_Fashion_MouseDown(object sender, MouseButtonEventArgs e) { }

		private void btn_cat_Health_MouseDown(object sender, MouseButtonEventArgs e) { }

		private void btn_cat_Education_MouseDown(object sender, MouseButtonEventArgs e) { }

		#endregion

	}

}
