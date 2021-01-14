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

namespace Quick_News_App
{
	public class NewsFeedData
	{ 
		public Image img { get; set; }
		public string headline { get; set; }		// 80 letters max
		public string news { get; set; }			// 250 letters max
		public string newsLink { get; set; }		
		public bool isBookmarked { get; set; }		
		public bool isMarkedAsRead { get; set; }		
	}

	// Get Data from database and store them all in list_NewsFeedData in Constructor [MainWindow()] and set totalNews = list_NewsFeedData.Count
	// Go to btn_NewsFeed_Next_MouseDown() and btn_NewsFeed_Previous_MouseDown()

	public partial class MainWindow : Window
	{
		private bool isLoggedIn = false;
		private bool isAdminLoggedIn = false;
		private string LoggedInUsername = "";
		private string DefaultUsername = "Guest";

		private List<NewsFeedData> list_NewsFeedData = new List<NewsFeedData>();

		private List<string> imgList_NewsFeedTest = new List<string>();
		private List<string> headlineList_NewsFeedTest = new List<string>();
		private List<string> newsList_NewsFeedTest = new List<string>();
		private int totalNews = 0;
		private int currentNews = 0;

		public MainWindow()
		{
			InitializeComponent();
			SubscribingEvents();
			btn_ThemeSwitcher.InitializeToggleSwitch(true);
			UpdateLoginLogoutAndSignupAdminPanelButtonsUI();

			// Sample Data Start
			imgList_NewsFeedTest.Add(@"C:\Users\MrTee\Desktop\Fall 2020\VPL\Project\Quick News App\Quick News App\Icons\A1_Test.jpg");
			imgList_NewsFeedTest.Add(@"C:\Users\MrTee\Desktop\Fall 2020\VPL\Project\Quick News App\Quick News App\Icons\A2_Test.jpg");
			imgList_NewsFeedTest.Add(@"C:\Users\MrTee\Desktop\Fall 2020\VPL\Project\Quick News App\Quick News App\Icons\A3_Test.jpg");

			headlineList_NewsFeedTest.Add("This is the Headline 01 Lorem ipsum dolor consectetur adipiscing. Praesent Lorem ipsum");
			headlineList_NewsFeedTest.Add("This is the Headline 02 Lorem ipsum dolor consectetur adipiscing. Praesent Lorem ipsum");
			headlineList_NewsFeedTest.Add("This is the Headline 03 Lorem ipsum dolor consectetur adipiscing. Praesent Lorem ipsum");

			newsList_NewsFeedTest.Add("This is the News 01. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque et luctus quam. Nunc sit amet vulputate mauris. Nulla facilisi. Maecenas. Lorem ipsum dolor sit amet, consectetur orem ipsum dolor sit amet, consectetur consectetur.....");
			newsList_NewsFeedTest.Add("This is the News 02. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque et luctus quam. Nunc sit amet vulputate mauris. Nulla facilisi. Maecenas. Lorem ipsum dolor sit amet, consectetur orem ipsum dolor sit amet, consectetur consectetur.....");
			newsList_NewsFeedTest.Add("This is the News 03. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque et luctus quam. Nunc sit amet vulputate mauris. Nulla facilisi. Maecenas. Lorem ipsum dolor sit amet, consectetur orem ipsum dolor sit amet, consectetur consectetur.....");
			// Sample Data End

			// get all news data from database and store it in list_NewsFeedData
			totalNews = imgList_NewsFeedTest.Count;
		}

		#region Title Bar Windows Buttons Functions

		private void DragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
		private void btn_Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
			SignupWindow.Singleton.Close();
			LoginWindow.Singleton.Close();
		}

		private void btn_Minimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

		#endregion

		#region Login / Signup / Admin Panel Button

		private void btn_LoginOrLogout_Click(object sender, RoutedEventArgs e) 
		{
			if (isLoggedIn == false)
			{
				// Perform Login Functionality
				LoginWindow.Singleton.Owner = this;		// Setting Login Window's Owner
				BlurGridEffect();						// Bluring background Window
				LoginWindow.Singleton.ShowDialog();
			}
			else
			{
				// Perform logout functionality
				isLoggedIn = false;
				isAdminLoggedIn = false;
				LoggedInUsername = DefaultUsername;

				// Updating UI
				txt_WelcomeMessage.Text = "Welcome, " + LoggedInUsername;
				txt_Name.Text = LoggedInUsername;
				UpdateLoginLogoutAndSignupAdminPanelButtonsUI();

				NavigateToThisScreen(Screens.MAIN);
			}
		}

		private void btn_SignupOrAdminPanel_Click(object sender, RoutedEventArgs e) 
		{
			if (isLoggedIn == false)
			{
				// Perform Signup Funtionality
				SignupWindow.Singleton.Owner = this;     // Setting Login Window's Owner
				BlurGridEffect();                       // Bluring background Window
				SignupWindow.Singleton.ShowDialog();
			}
			else
			{
				// Perform Admin Panel Funtionality
				NavigateToThisScreen(Screens.ADMIN_PANEL);
			}
		}


		#endregion

		#region Main Screen Buttons

		#region Main Buttons

		private void btn_Search_Click(object sender, RoutedEventArgs e) { }

			private void btn_Bookmark_Click(object sender, RoutedEventArgs e) { }

			private void btn_ReadHistory_Click(object sender, RoutedEventArgs e) { }

			private void btn_NewsFeed_Click(object sender, RoutedEventArgs e)
			{
				NavigateToThisScreen(Screens.NEWS_FEED);
				currentNews = 0;
			} 

		#endregion

			#region Categories Buttons

			private void btn_cat_Politics_MouseUp(object sender, MouseButtonEventArgs e) { }

			private void btn_cat_Sports_MouseUp(object sender, MouseButtonEventArgs e) { }

			private void btn_cat_Business_MouseUp(object sender, MouseButtonEventArgs e) { }

			private void btn_cat_Science_MouseUp(object sender, MouseButtonEventArgs e) { }

			private void btn_cat_Automobile_MouseUp(object sender, MouseButtonEventArgs e) { }

			private void btn_cat_Fashion_MouseUp(object sender, MouseButtonEventArgs e) { }

			private void btn_cat_Health_MouseUp(object sender, MouseButtonEventArgs e) { }

			private void btn_cat_Education_MouseUp(object sender, MouseButtonEventArgs e) { }

		#endregion

		#endregion

		#region News Feed Screen Buttons

			#region News Feed Main Buttons

				private void btn_NewsFeed_ReadMore_Click(object sender, RoutedEventArgs e) => System.Diagnostics.Process.Start("http://www.google.com");

				private void btn_NewsFeed_Bookmark_MouseUp(object sender, MouseButtonEventArgs e)
				{
					if (btn_NewsFeed_Bookmark.isSelected)
						btn_NewsFeed_Bookmark.ImageSource = (BitmapImage)FindResource("icon_NotBookmarked");
					else
						btn_NewsFeed_Bookmark.ImageSource = (BitmapImage)FindResource("icon_Bookmarked");

					btn_NewsFeed_Bookmark.isSelected = !btn_NewsFeed_Bookmark.isSelected;
				}

				private void btn_NewsFeed_MarkAsRead_MouseUp(object sender, MouseButtonEventArgs e)
				{
					if (btn_NewsFeed_MarkAsRead.isSelected)
						btn_NewsFeed_MarkAsRead.ImageSource = (BitmapImage)FindResource("icon_Unread");
					else
						btn_NewsFeed_MarkAsRead.ImageSource = (BitmapImage)FindResource("icon_Read");

					btn_NewsFeed_MarkAsRead.isSelected = !btn_NewsFeed_MarkAsRead.isSelected;
				}

		#endregion

			#region Navigation Buttons

		private void btn_NewsFeed_Next_MouseDown(object sender, MouseButtonEventArgs e) 
		{
			if (currentNews < (totalNews - 1))
			{
				currentNews++;
				img_NewsFeed.Source = new BitmapImage(new Uri(imgList_NewsFeedTest[currentNews]));  // list_NewsFeedData[currentNews].img;
				txt_NewsFeed_Headline.Text = headlineList_NewsFeedTest[currentNews];                // list_NewsFeedData[currentNews].headline;
				txt_NewsFeed_News.Text = newsList_NewsFeedTest[currentNews];
			}

			if (currentNews == (totalNews - 1))
				btn_NewsFeed_Next.ImageSource = (BitmapImage)FindResource("icon_NoItemsLeft");
			
			if(currentNews > 0)
				btn_NewsFeed_Previous.ImageSource = (BitmapImage)FindResource("icon_Previous");
		}

		private void btn_NewsFeed_Previous_MouseDown(object sender, MouseButtonEventArgs e) 
		{
			if (currentNews != 0)
			{
				currentNews--;
				img_NewsFeed.Source = new BitmapImage(new Uri(imgList_NewsFeedTest[currentNews]));		// same thing here
				txt_NewsFeed_Headline.Text = headlineList_NewsFeedTest[currentNews];
				txt_NewsFeed_News.Text = newsList_NewsFeedTest[currentNews];
			}

			if(currentNews == 0)
				btn_NewsFeed_Previous.ImageSource = (BitmapImage)FindResource("icon_NoItemsLeft");

			if (currentNews != (totalNews - 1))
				btn_NewsFeed_Next.ImageSource = (BitmapImage)FindResource("icon_Next");
		}

		private void btn_NewsFeed_GoBack_MouseUp(object sender, MouseButtonEventArgs e) => NavigateToThisScreen(Screens.MAIN);

		#endregion

		#endregion

		#region Events related Methods

		private void SubscribingEvents()
		{
			LoginWindow.Singleton.OnLoginPressed += LoginWindowEvent_OnLoginPressed;
			LoginWindow.Singleton.OnLoginWindowClosed += LoginWindowEvent_OnLoginWindowClosed;

			SignupWindow.Singleton.OnSignupPressed += SignupWindowEvent_OnSignupPressed;
			SignupWindow.Singleton.OnSignupWindowClosed += SignupWindowEvent_OnSignupWindowClosed;
		}

		private void LoginWindowEvent_OnLoginPressed(bool isLoggedIn, bool isAdminLoggedIn, string LoggedInUsername)
		{
			this.isLoggedIn = isLoggedIn;
			this.isAdminLoggedIn = isAdminLoggedIn;
			this.LoggedInUsername = LoggedInUsername;

			// Updating UI
			txt_WelcomeMessage.Text = "Welcome, " + LoggedInUsername;
			txt_Name.Text = LoggedInUsername;
			UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
		}
		private void SignupWindowEvent_OnSignupPressed(string LoggedInUsername)
		{
			this.isLoggedIn = true;
			this.isAdminLoggedIn = false;
			this.LoggedInUsername = LoggedInUsername;

			// Updating UI
			txt_WelcomeMessage.Text = "Welcome, " + LoggedInUsername;
			txt_Name.Text = LoggedInUsername;
			UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
		}


		// Removing Blur from background Window
		private void LoginWindowEvent_OnLoginWindowClosed() => UndoAllGridEffects();
		private void SignupWindowEvent_OnSignupWindowClosed() => UndoAllGridEffects();     
		

		#endregion

		#region Utility Methods

		private void NavigateToThisScreen(Screens screen)
		{
			switch (screen)
			{
				case Screens.MAIN:
					TabControl_MainWindow.SelectedItem = tab_MainScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_MainScreen_UpperPart;
					windowTitle.Text = "Quick News";
					btn_SignupOrAdminPanel.Visibility = Visibility.Visible;
					break;
				case Screens.NEWS_FEED:
					TabControl_MainWindow.SelectedItem = tab_NewsFeedScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_AllOtherScreens_UpperPart;
					windowTitle.Text = "Quick News - News Feed";
					break;
				case Screens.ADMIN_PANEL:
					TabControl_MainWindow.SelectedItem = tab_AdminPanelScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_AllOtherScreens_UpperPart;
					windowTitle.Text = "Quick News - Admin Panel";
					btn_SignupOrAdminPanel.Visibility = Visibility.Collapsed;
					break;
			}
		}


		public void BlurGridEffect() => MainGrid.Effect = new BlurEffect();
		public void UndoAllGridEffects() => MainGrid.Effect = null;


		public void UpdateLoginLogoutAndSignupAdminPanelButtonsUI()
		{
			if (isLoggedIn)
			{
				if (isAdminLoggedIn)
					btn_SignupOrAdminPanel.CusBtn_Content = "Admin Panel";
				else
					btn_SignupOrAdminPanel.Visibility = Visibility.Collapsed;

				btn_LoginOrLogout.CusBtn_Content = "Logout";
			}
			else
			{
				btn_LoginOrLogout.CusBtn_Content = "Login";
				btn_SignupOrAdminPanel.Visibility = Visibility.Visible;
				btn_SignupOrAdminPanel.CusBtn_Content = "Sign Up";
			}
		}

		#endregion
	}

	public enum Screens
	{ 
		MAIN,
		NEWS_FEED,
		ADMIN_PANEL
	}

}
