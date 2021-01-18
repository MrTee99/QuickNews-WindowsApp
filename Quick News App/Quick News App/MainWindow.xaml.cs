using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
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
using Microsoft.Win32;
using Quick_News_App.Custom_User_Controls;
using Quick_News_App.Modules;

namespace Quick_News_App
{
	public partial class MainWindow : Window
	{
		private QuickNewsDatabaseDataContext _db = new QuickNewsDatabaseDataContext();

		private bool isLoggedIn = false;
		private bool isAdminLoggedIn = false;
		private string LoggedInUsername = "";
		private int LoggedInUserID = 0;
		private string DefaultUsername = "Guest";

		private List<NewsModelForItemsControl> list_newsModelForItemsControls = new List<NewsModelForItemsControl>();
		private List<NewsTable> NewsList = new List<NewsTable>();
		private List<UserTable> UsersList = new List<UserTable>();
		private int currentNews = 0;

		private bool isUpdatingNews = false;
		private int newsIDofCurrentlyUpdatingNews = -1;

		public MainWindow()
		{
			InitializeComponent();
			SubscribingEvents();
			btn_ThemeSwitcher.InitializeToggleSwitch(false);
			UpdateLoginLogoutAndSignupAdminPanelButtonsUI();

			LoadCategoryDataInComboBox(combobox_AddAndUpdateNews_Category);
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
				ApplyBlurEffectOnMainGridUI();						// Bluring background Window
				LoginWindow.Singleton.ShowDialog();
			}
			else
			{
				// Perform logout functionality
				isLoggedIn = false;
				isAdminLoggedIn = false;
				LoggedInUsername = DefaultUsername;
				LoggedInUserID = 0;

				// Updating UI
				txt_WelcomeMessage.Text = "Welcome, " + LoggedInUsername;
				txt_Name.Text = LoggedInUsername;
				UpdateLoginLogoutAndSignupAdminPanelButtonsUI();

				NavigateToThisScreenUI(Screens.MAIN);
			}
		}

		private void btn_SignupOrAdminPanel_Click(object sender, RoutedEventArgs e) 
		{
			if (isLoggedIn == false)
			{
				// Perform Signup Funtionality
				SignupWindow.Singleton.Owner = this;     // Setting Login Window's Owner
				ApplyBlurEffectOnMainGridUI();                       // Bluring background Window
				SignupWindow.Singleton.ShowDialog();
			}
			else
			{
				// Perform Admin Panel Funtionality
				NavigateToThisScreenUI(Screens.ADMIN_PANEL);
			}
		}


		#endregion

		#region Main Screen Buttons

		#region Main Buttons

		private void btn_Search_Click(object sender, RoutedEventArgs e) 
		{
			UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereThisSearchMatchesInHeadline(input_SearchNews.Text.Trim()));
		}

		private void btn_ReadHistory_Click(object sender, RoutedEventArgs e)
		{
			RefeshDataForMarkedAsReadIn_UpdateNewsModelForItemsControlsList();
			NavigateToThisScreenUI(Screens.MY_READ_HISTORY);

			UpdateViewMyMarkedAsReadUI();

			itemsControl_ReadHistory.ItemsSource = null;
			itemsControl_ReadHistory.ItemsSource = list_newsModelForItemsControls;
		}

		private void btn_Bookmark_Click(object sender, RoutedEventArgs e)
		{
			RefreshDataForBookmarksIn_UpdateNewsModelForItemsControlsList();
			NavigateToThisScreenUI(Screens.MY_BOOKMARKS);

			UpdateViewMyBookmarksUI();

			itemsControl_Bookmarks.ItemsSource = null;
			itemsControl_Bookmarks.ItemsSource = list_newsModelForItemsControls;
		}

		private void btn_NewsFeed_Click(object sender, RoutedEventArgs e)
		{
			RefreshDataInNewsList();
			UpdateNewsListDataWithThisListAndOpenNewsFeedUI(null, true);
		}

		#endregion

		#region Categories Buttons

		private void btn_cat_Politics_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(1));
		private void btn_cat_Sports_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(2));
		private void btn_cat_Business_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(3));
		private void btn_cat_Science_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(4));
		private void btn_cat_Automobile_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(5));
		private void btn_cat_Fashion_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(6));
		private void btn_cat_Health_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(7));
		private void btn_cat_Education_MouseUp(object sender, MouseButtonEventArgs e) => UpdateNewsListDataWithThisListAndOpenNewsFeedUI(GetAllNewsWhereCategoryIDIsThis(8));

		#endregion

		#endregion

		#region News Feed Screen Buttons

		#region News Feed Main Buttons

		private void btn_NewsFeed_ReadMore_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(NewsList[currentNews].NewsLink);
			}
			catch (Exception)
			{
				System.Diagnostics.Process.Start("https://www.google.com");
			}
			
		}

		private void btn_NewsFeed_Bookmark_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (isLoggedIn == false)
			{
				MessageBox.Show("To use this feature please login or signup", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}

			if (btn_NewsFeed_Bookmark.isSelected)
			{
				btn_NewsFeed_Bookmark.ImageSource = (BitmapImage)FindResource("icon_NotBookmarked");

				var bm = GetBookmarkWhereUserAndNewsIsThis(LoggedInUserID, NewsList[currentNews].News_ID);
				if (bm != null)
				{
					_db.BookmarkInfoTables.DeleteOnSubmit(bm);
					_db.SubmitChanges();
				}
			}
			else
			{
				btn_NewsFeed_Bookmark.ImageSource = (BitmapImage)FindResource("icon_Bookmarked");

				BookmarkInfoTable newBookMark = new BookmarkInfoTable();
				newBookMark.News_ID = NewsList[currentNews].News_ID;
				newBookMark.User_ID = LoggedInUserID;
				_db.BookmarkInfoTables.InsertOnSubmit(newBookMark);
				_db.SubmitChanges();
			}

			btn_NewsFeed_Bookmark.isSelected = !btn_NewsFeed_Bookmark.isSelected;
		}

		private void btn_NewsFeed_MarkAsRead_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (isLoggedIn == false)
			{
				MessageBox.Show("To use this feature please login or signup", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}

			if (btn_NewsFeed_MarkAsRead.isSelected)
			{
				btn_NewsFeed_MarkAsRead.ImageSource = (BitmapImage)FindResource("icon_Unread");

				var mar = GetMarkAsReadWhereUserAndNewsIsThis(LoggedInUserID, NewsList[currentNews].News_ID);
				if (mar != null)
				{
					_db.MarkedAsReadInfoTables.DeleteOnSubmit(mar);
					_db.SubmitChanges();
				}
			}
			else
			{
				btn_NewsFeed_MarkAsRead.ImageSource = (BitmapImage)FindResource("icon_Read");

				MarkedAsReadInfoTable newMark = new MarkedAsReadInfoTable();
				newMark.News_ID = NewsList[currentNews].News_ID;
				newMark.User_ID = LoggedInUserID;
				_db.MarkedAsReadInfoTables.InsertOnSubmit(newMark);
				_db.SubmitChanges();
			}

			btn_NewsFeed_MarkAsRead.isSelected = !btn_NewsFeed_MarkAsRead.isSelected;
		}

		#endregion

			#region Navigation Buttons

		private void btn_NewsFeed_Next_MouseDown(object sender, MouseButtonEventArgs e) 
		{
			if (currentNews < (NewsList.Count - 1))
			{
				currentNews++;
				UpdateAndDisplayNewsInNewsFeedUI();
			}

			UpdateNewsFeedNavigationButtonUI();
		}

		private void btn_NewsFeed_Previous_MouseDown(object sender, MouseButtonEventArgs e) 
		{
			if (currentNews != 0)
			{
				currentNews--;
				UpdateAndDisplayNewsInNewsFeedUI();
			}

			UpdateNewsFeedNavigationButtonUI();
		}

		private void btn_NewsFeed_GoBack_MouseUp(object sender, MouseButtonEventArgs e) => NavigateToThisScreenUI(Screens.MAIN);

		#endregion

		#endregion

		#region My Bookmarks Screen

		private void btn_ItemsControl_RemoveBookmark_Click(object sender, RoutedEventArgs e)
		{
			int newsID = Convert.ToInt32(((Button)sender).Tag);
			var bm = GetBookmarkWhereUserAndNewsIsThis(LoggedInUserID, newsID);
			if (bm != null)
			{
				_db.BookmarkInfoTables.DeleteOnSubmit(bm);
				_db.SubmitChanges();
			}

			RefreshDataForBookmarksIn_UpdateNewsModelForItemsControlsList();
			UpdateViewMyBookmarksUI();

			itemsControl_Bookmarks.ItemsSource = null;
			itemsControl_Bookmarks.ItemsSource = list_newsModelForItemsControls;

			MessageBox.Show("Success: News is removed from your bookmarks successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
			ClearAddNewsFormInputFieldsUI();
		}

		#endregion

		#region My Read History / Marked as Read History Screen

		private void btn_ItemsControl_RemoveMarkAsRead_Click(object sender, RoutedEventArgs e)
		{
			int newsID = Convert.ToInt32(((Button)sender).Tag);
			var mar = GetMarkAsReadWhereUserAndNewsIsThis(LoggedInUserID, newsID);
			if (mar != null)
			{
				_db.MarkedAsReadInfoTables.DeleteOnSubmit(mar);
				_db.SubmitChanges();
			}

			RefeshDataForMarkedAsReadIn_UpdateNewsModelForItemsControlsList();
			UpdateViewMyMarkedAsReadUI();

			itemsControl_ReadHistory.ItemsSource = null;
			itemsControl_ReadHistory.ItemsSource = list_newsModelForItemsControls;

			MessageBox.Show("Success: News is removed from your read history successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
			ClearAddNewsFormInputFieldsUI();
		}

		#endregion

		#region Admin Panel Screen Buttons

		#region Tab Controls Menu Buttons

		private void btn_OpenAddNewsTab_Click(object sender, RoutedEventArgs e)
		{
			UpdateAdminPanelMenuSelectedButtonColorUI(btn_OpenAddNewsTab);

			// Load Data in combo box
			LoadCategoryDataInComboBox(combobox_AddAndUpdateNews_Category);

			// Clear Add News Fields
			ClearAddNewsFormInputFieldsUI();

			// Open Add news tab
			txt_AddAndUpdateNews_Heading.Text = "Add news";
			btn_AddAndUpdateNews.CusBtn_Content = "Add news";
			btn_AddAndUpdateNews.CusBtn_Padding = new Thickness(106, 7, 106, 7);
			TabControl_AdminPanel.SelectedItem = tab_AddNews;
		}
		private void btn_OpenUpdateNewsTab_Click(object sender, RoutedEventArgs e)
		{
			UpdateAdminPanelMenuSelectedButtonColorUI(btn_OpenUpdateNewsTab);

			RefreshDataInNewsList();
			RefreshDataIn_NewsModelForItemsControlsList();

			UpdateNews_NewsNotAvailable.Visibility = (NewsList.Count <= 0) ? Visibility.Visible : Visibility.Hidden;
			TabControl_AdminPanel.SelectedItem = tab_UpdateNews;
			itemsControl_UpdateNews.ItemsSource = null;
			itemsControl_UpdateNews.ItemsSource = list_newsModelForItemsControls;
		}
		private void btn_OpenDeleteNewsTab_Click(object sender, RoutedEventArgs e)
		{
			UpdateAdminPanelMenuSelectedButtonColorUI(btn_OpenDeleteNewsTab);

			RefreshDataInNewsList();
			RefreshDataIn_NewsModelForItemsControlsList();

			DeleteNews_NewsNotAvailable.Visibility = (NewsList.Count <= 0) ? Visibility.Visible : Visibility.Hidden;
			TabControl_AdminPanel.SelectedItem = tab_DeleteNews;
			itemsControl_DeleteNews.ItemsSource = null;
			itemsControl_DeleteNews.ItemsSource = list_newsModelForItemsControls;
		}
		private void btn_OpenViewAllNewsTab_Click(object sender, RoutedEventArgs e)
		{
			UpdateAdminPanelMenuSelectedButtonColorUI(btn_OpenViewAllNewsTab);

			RefreshDataInNewsList();
			RefreshDataIn_NewsModelForItemsControlsList();

			ViewAllNews_NewsNotAvailable.Visibility = (NewsList.Count <= 0) ? Visibility.Visible : Visibility.Hidden;
			TabControl_AdminPanel.SelectedItem = tab_ViewAllNews;
			itemsControl_ViewAllNews.ItemsSource = null;
			itemsControl_ViewAllNews.ItemsSource = list_newsModelForItemsControls;
		}
		private void btn_OpenDeleteUserTab_Click(object sender, RoutedEventArgs e) 
		{
			UpdateAdminPanelMenuSelectedButtonColorUI(btn_OpenDeleteUserTab);

			TabControl_AdminPanel.SelectedItem = tab_DeleteUser;
			itemsControl_DeleteUser.ItemsSource = null;
			itemsControl_DeleteUser.ItemsSource = _db.UserTables.ToList();
		}
		private void btn_OpenViewAllUsersTab_Click(object sender, RoutedEventArgs e)
		{
			UpdateAdminPanelMenuSelectedButtonColorUI(btn_OpenViewAllUsersTab);

			TabControl_AdminPanel.SelectedItem = tab_ViewAllUsers;
			itemsControl_ViewAllUsers.ItemsSource = null;
			itemsControl_ViewAllUsers.ItemsSource = _db.UserTables.ToList();
		}

		#endregion

		#region Add News Related Methods

		private void btn_AddNews_OpenImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Title = "Select an image";
			open.Filter = "(*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";
			if (open.ShowDialog() == true)
			{
				img_AddAndUpdateNews.Source = new BitmapImage(new Uri(open.FileName));
			}
		}

		private void btn_AddAndUpdateNews_Click(object sender, RoutedEventArgs e)
		{
			var headline = input_AddAndUpdatenews_Headline.Text.Trim();
			var news = input_AddAndUpdateNewws_News.Text.Trim();
			var link = input_AddAndUpdateNews_link.Text.Trim();
			var category = combobox_AddAndUpdateNews_Category.SelectedValue;
			var imgData = ConvertImageToByteArray(img_AddAndUpdateNews.Source as BitmapImage);

			if (headline == "" || news == "" || link == "" || category == null || imgData == null)
			{
				string headlineMsg = "Headline field is empty";
				string newsMsg = "News field is empty";
				string linkMsg = "Website Link of the news is not provided";
				string categoryMsg = "Category is not selected";
				string imageMsg = "Image of news is not added";

				string message = (headline == "") ? headlineMsg : (news == "") ? newsMsg : (link == "") ? linkMsg : (category == null) ? categoryMsg : imageMsg;
				MessageBox.Show("Error: " + message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			if (isUpdatingNews == false)
			{
				var addingNewNews = new NewsTable();
				addingNewNews.Headline = headline;
				addingNewNews.News = news;
				addingNewNews.NewsLink = link;
				addingNewNews.Category_ID = (int)category;
				addingNewNews.Image = imgData;

				_db.NewsTables.InsertOnSubmit(addingNewNews);
				_db.SubmitChanges();

				MessageBox.Show("Success: News added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
				ClearAddNewsFormInputFieldsUI();
			}
			else
			{
				var updatingThisNews = (from newsItem in _db.NewsTables where newsItem.News_ID == newsIDofCurrentlyUpdatingNews select newsItem).First();
				updatingThisNews.Headline = headline;
				updatingThisNews.News = news;
				updatingThisNews.NewsLink = link;
				updatingThisNews.Category_ID = (int)category;
				updatingThisNews.Image = imgData;

				_db.SubmitChanges();

				MessageBox.Show("Success: News updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
				ClearAddNewsFormInputFieldsUI();

				RefreshDataInNewsList();
				RefreshDataIn_NewsModelForItemsControlsList();

				TabControl_AdminPanel.SelectedItem = tab_UpdateNews;
				itemsControl_UpdateNews.ItemsSource = null;
				itemsControl_UpdateNews.ItemsSource = list_newsModelForItemsControls;

				isUpdatingNews = true;
				newsIDofCurrentlyUpdatingNews = -1;
			}
		}

		#endregion

		#region Delete News and User Related Methods

		private void btn_ItemsControl_DeleteNews_Click(object sender, RoutedEventArgs e)
		{
			int newsID = Convert.ToInt32(((Button)sender).Tag);

			// Delete all bookmarks of this news ID
			var list_bm = GetAllBookmarksOfThisNewsID(newsID);
			if (list_bm != null)
			{
				foreach (var bm in list_bm)
				{
					_db.BookmarkInfoTables.DeleteOnSubmit(bm);
					_db.SubmitChanges();
				}
			}

			// Delete all Marked As Read of this news ID
			var list_mar = GetAllMarkedAsReadOfThisNewsID(newsID);
			if (list_mar != null)
			{
				foreach (var mar in list_mar)
				{
					_db.MarkedAsReadInfoTables.DeleteOnSubmit(mar);
					_db.SubmitChanges();
				}
			}

			// Deleting news of this news ID
			var news = GetNewsWhereNewsIDIsThis(newsID);
			if (news != null)
			{
				_db.NewsTables.DeleteOnSubmit(news);
				_db.SubmitChanges();
			}

			// Updating Delete News Screen UI
			DeleteNews_NewsNotAvailable.Visibility = (NewsList.Count <= 0) ? Visibility.Visible : Visibility.Hidden;
			RefreshDataInNewsList();
			RefreshDataIn_NewsModelForItemsControlsList();

			itemsControl_DeleteNews.ItemsSource = null;
			itemsControl_DeleteNews.ItemsSource = list_newsModelForItemsControls;

			MessageBox.Show("Success: News Deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void btn_ItemsControl_DeleteUser_Click(object sender, RoutedEventArgs e)
		{
			int userID = Convert.ToInt32(((Button)sender).Tag);

			if (userID == 1)
			{
				MessageBox.Show("Faileed: Admin cannot be deleted", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			// Delete all bookmarks of this user ID
			var list_bm = GetAllBookmarksOfThisUserID(userID);
			if (list_bm != null)
			{
				foreach (var bm in list_bm)
				{
					_db.BookmarkInfoTables.DeleteOnSubmit(bm);
					_db.SubmitChanges();
				}
			}

			// Delete all Marked As Read of this user ID
			var list_mar = GetAllMarkedAsReadOfThisUserID(userID);
			if (list_mar != null)
			{
				foreach (var mar in list_mar)
				{
					_db.MarkedAsReadInfoTables.DeleteOnSubmit(mar);
					_db.SubmitChanges();
				}
			}

			// Deleting news of this user ID
			var user = GetUserWhereUserIDIsThis(userID);
			if (user != null)
			{
				_db.UserTables.DeleteOnSubmit(user);
				_db.SubmitChanges();
			}

			// Updating Delete News Screen UI
			RefreshDataInNewsList();
			RefreshDataIn_NewsModelForItemsControlsList();

			itemsControl_DeleteUser.ItemsSource = null;
			itemsControl_DeleteUser.ItemsSource = list_newsModelForItemsControls;

			MessageBox.Show("Success: User is Deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		#endregion

		#region Update News Related Methods

		private void btn_ItemsControl_EditNews_Click(object sender, RoutedEventArgs e)
		{
			int newsID = Convert.ToInt32(((Button)sender).Tag);

			var news = GetNewsWhereNewsIDIsThis(newsID);

			input_AddAndUpdatenews_Headline.Text = news.Headline;
			input_AddAndUpdateNewws_News.Text = news.News;
			input_AddAndUpdateNews_link.Text = news.NewsLink;
			combobox_AddAndUpdateNews_Category.SelectedValue = news.Category_ID;
			img_AddAndUpdateNews.Source = ConvertByteArrayToImage(news.Image.ToArray());

			txt_AddAndUpdateNews_Heading.Text = "Update news";
			btn_AddAndUpdateNews.CusBtn_Content = "Update News";
			btn_AddAndUpdateNews.CusBtn_Padding = new Thickness(91, 7, 91, 7);
			TabControl_AdminPanel.SelectedItem = tab_AddNews;

			isUpdatingNews = true;
			newsIDofCurrentlyUpdatingNews = newsID;
		}

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

		private void LoginWindowEvent_OnLoginPressed(bool isLoggedIn, bool isAdminLoggedIn, string LoggedInUsername, int LoggedInUserID)
		{
			this.isLoggedIn = isLoggedIn;
			this.isAdminLoggedIn = isAdminLoggedIn;
			this.LoggedInUsername = LoggedInUsername;
			this.LoggedInUserID = LoggedInUserID;

			// Updating UI
			txt_WelcomeMessage.Text = "Welcome, " + LoggedInUsername;
			txt_Name.Text = LoggedInUsername;
		
			NavigateToThisScreenUI(Screens.MAIN);
			UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
		}
		private void SignupWindowEvent_OnSignupPressed(string LoggedInUsername, int LoggedInUserID)
		{
			this.isLoggedIn = true;
			this.isAdminLoggedIn = false;
			this.LoggedInUsername = LoggedInUsername;
			this.LoggedInUserID = LoggedInUserID;

			// Updating UI
			txt_WelcomeMessage.Text = "Welcome, " + LoggedInUsername;
			txt_Name.Text = LoggedInUsername;

			NavigateToThisScreenUI(Screens.MAIN);
			UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
		}


		// Removing Blur from background Window
		private void LoginWindowEvent_OnLoginWindowClosed() => RemoveBlurEffectFromMainGridUI();
		private void SignupWindowEvent_OnSignupWindowClosed() => RemoveBlurEffectFromMainGridUI();     
		

		#endregion

		#region Utility Methods

		#region Convert Bitmap Image to Byte Array and Vice versa

		private byte[] ConvertImageToByteArray(System.Windows.Media.Imaging.BitmapImage img)
		{
			if (img != null)
			{
				MemoryStream memStream = new MemoryStream();
				JpegBitmapEncoder encoder = new JpegBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(img));
				encoder.Save(memStream);
				return memStream.ToArray();
			}
			return null;
		}

		private BitmapImage ConvertByteArrayToImage(byte[] imageByteArray)
		{
			// retrieval => imgTest.Source = ConvertByteArrayToImage(b);

			BitmapImage img = new BitmapImage();
			using (MemoryStream memStream = new MemoryStream(imageByteArray))
			{
				img.BeginInit();
				img.CacheOption = BitmapCacheOption.OnLoad;
				img.StreamSource = memStream;
				img.EndInit();
				img.Freeze();
			}
			return img;
		}

		#endregion

		#region LINQ Queries Related Methods

		private void LoadCategoryDataInComboBox(ComboBox comboBox)
		{
			List<CategoryTable> categories = _db.CategoryTables.ToList();
			comboBox.DisplayMemberPath = "CategoryName";
			comboBox.SelectedValuePath = "Category_ID";
			comboBox.ItemsSource = categories;
		}
		private void RefreshDataInNewsList()
		{
			NewsList = _db.NewsTables.ToList();
			currentNews = 0;
		}
		private void RefreshDataIn_NewsModelForItemsControlsList()
		{
			list_newsModelForItemsControls.Clear();
			foreach (var item in NewsList)
			{
				var headline = item.Headline;
				var category = GetCategoryName(item.Category_ID);
				var newsID = item.News_ID.ToString();
				var image = ConvertByteArrayToImage(item.Image.ToArray());

				var addThisItem = new NewsModelForItemsControl(headline, category, newsID, image);
				list_newsModelForItemsControls.Add(addThisItem);
			}
		}
		private void RefreshDataForBookmarksIn_UpdateNewsModelForItemsControlsList()
		{

			list_newsModelForItemsControls.Clear();
			List<BookmarkInfoTable> bookmarkInfoTablesList = (from bookmark in _db.BookmarkInfoTables where bookmark.User_ID == LoggedInUserID select bookmark).ToList();
			List<NewsTable> UserBookmarkedNewsList = new List<NewsTable>();

			foreach (var item in bookmarkInfoTablesList)
			{
				var news = (from n in _db.NewsTables where n.News_ID == item.News_ID select n).FirstOrDefault();
				UserBookmarkedNewsList.Add(news);
			}

			foreach (var item in UserBookmarkedNewsList)
			{
				var headline = item.Headline;
				var category = GetCategoryName(item.Category_ID);
				var newsID = item.News_ID.ToString();
				var image = ConvertByteArrayToImage(item.Image.ToArray());

				var addThisItem = new NewsModelForItemsControl(headline, category, newsID, image);
				list_newsModelForItemsControls.Add(addThisItem);
			}
		}
		private void RefeshDataForMarkedAsReadIn_UpdateNewsModelForItemsControlsList()
		{
			list_newsModelForItemsControls.Clear();
			List<MarkedAsReadInfoTable> markedAsReadInfoTablesList = (from readHistory in _db.MarkedAsReadInfoTables where readHistory.User_ID == LoggedInUserID select readHistory).ToList();
			List<NewsTable> UserBookmarkedNewsList = new List<NewsTable>();

			foreach (var item in markedAsReadInfoTablesList)
			{
				var news = (from n in _db.NewsTables where n.News_ID == item.News_ID select n).FirstOrDefault();
				UserBookmarkedNewsList.Add(news);
			}

			foreach (var item in UserBookmarkedNewsList)
			{
				var headline = item.Headline;
				var category = GetCategoryName(item.Category_ID);
				var newsID = item.News_ID.ToString();
				var image = ConvertByteArrayToImage(item.Image.ToArray());

				var addThisItem = new NewsModelForItemsControl(headline, category, newsID, image);
				list_newsModelForItemsControls.Add(addThisItem);
			}
		}
		private string GetCategoryName(int categoryID) => "Category - " + (from cat in _db.CategoryTables where cat.Category_ID == categoryID select cat.CategoryName).FirstOrDefault();
		private List<NewsTable> GetAllNewsWhereThisSearchMatchesInHeadline(string searchThis) => (from news in _db.NewsTables where news.Headline.Contains(searchThis) select news).ToList();
		private List<NewsTable> GetAllNewsWhereCategoryIDIsThis(int categoryID) => (from news in _db.NewsTables where news.Category_ID == categoryID select news).ToList();
		private NewsTable GetNewsWhereNewsIDIsThis(int newsID) => (from news in _db.NewsTables where news.News_ID == newsID select news).FirstOrDefault();
		private UserTable GetUserWhereUserIDIsThis(int userID) => (from user in _db.UserTables where user.User_ID == userID select user).FirstOrDefault();		
		private BookmarkInfoTable GetBookmarkWhereUserAndNewsIsThis(int User_ID, int newsID) => (from bookmark in _db.BookmarkInfoTables where bookmark.User_ID == User_ID && bookmark.News_ID == newsID select bookmark).FirstOrDefault();
		private List<BookmarkInfoTable> GetAllBookmarksOfThisNewsID(int newsID) => (from bookmark in _db.BookmarkInfoTables where bookmark.News_ID == newsID select bookmark).ToList();
		private List<BookmarkInfoTable> GetAllBookmarksOfThisUserID(int userID) => (from bookmark in _db.BookmarkInfoTables where bookmark.User_ID == userID select bookmark).ToList();
		private MarkedAsReadInfoTable GetMarkAsReadWhereUserAndNewsIsThis(int User_ID, int newsID) => (from mark in _db.MarkedAsReadInfoTables where mark.User_ID == User_ID && mark.News_ID == newsID select mark).FirstOrDefault();
		private List<MarkedAsReadInfoTable> GetAllMarkedAsReadOfThisNewsID(int newsID) => (from mark in _db.MarkedAsReadInfoTables where mark.News_ID == newsID select mark).ToList();
		private List<MarkedAsReadInfoTable> GetAllMarkedAsReadOfThisUserID(int UserID) => (from mark in _db.MarkedAsReadInfoTables where mark.User_ID == UserID select mark).ToList();

		#endregion

		#region Update UI Methods

		private void NavigateToThisScreenUI(Screens screen)
		{
			switch (screen)
			{
				case Screens.MAIN:
					TabControl_MainWindow.SelectedItem = tab_MainScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_MainScreen_UpperPart;
					windowTitle.Text = "Quick News";
					UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
					break;
				case Screens.NEWS_FEED:
					TabControl_MainWindow.SelectedItem = tab_NewsFeedScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_AllOtherScreens_UpperPart;
					windowTitle.Text = "Quick News - News Feed";
					UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
					break;
				case Screens.ADMIN_PANEL:
					TabControl_MainWindow.SelectedItem = tab_AdminPanelScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_AllOtherScreens_UpperPart;
					windowTitle.Text = "Quick News - Admin Panel";
					UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
					UpdateAdminPanelMenuSelectedButtonColorUI(btn_OpenAddNewsTab);
					break;
				case Screens.MY_BOOKMARKS:
					TabControl_MainWindow.SelectedItem = tab_BookmarkScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_AllOtherScreens_UpperPart;
					windowTitle.Text = "Quick News - My Bookmarks";
					UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
					break;
				case Screens.MY_READ_HISTORY:
					TabControl_MainWindow.SelectedItem = tab_ReadHistoryScreen;
					TabControl_MainWindow_UpperPart.SelectedItem = tab_AllOtherScreens_UpperPart;
					windowTitle.Text = "Quick News - My Read History";
					UpdateLoginLogoutAndSignupAdminPanelButtonsUI();
					break;
			}
		}
		private void ApplyBlurEffectOnMainGridUI() => MainGrid.Effect = new BlurEffect();
		private void RemoveBlurEffectFromMainGridUI() => MainGrid.Effect = null;
		private void ClearAddNewsFormInputFieldsUI()
		{
			input_AddAndUpdatenews_Headline.Text = "";
			input_AddAndUpdateNewws_News.Text = "";
			input_AddAndUpdateNews_link.Text = "";
			combobox_AddAndUpdateNews_Category.SelectedIndex = -1;
			img_AddAndUpdateNews.Source = null;
		}
		private void UpdateLoginLogoutAndSignupAdminPanelButtonsUI()
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
		private void UpdateNewsFeedBookMarkButtonUI()
		{
			if (GetBookmarkWhereUserAndNewsIsThis(LoggedInUserID, NewsList[currentNews].News_ID) == null)
			{
				btn_NewsFeed_Bookmark.isSelected = false;
				btn_NewsFeed_Bookmark.ImageSource = (BitmapImage)FindResource("icon_NotBookmarked");
			}
			else
			{
				btn_NewsFeed_Bookmark.isSelected = true;
				btn_NewsFeed_Bookmark.ImageSource = (BitmapImage)FindResource("icon_Bookmarked");
			}
		}
		private void UpdateNewsFeedMarkAsReadButtonUI()
		{
			if (GetMarkAsReadWhereUserAndNewsIsThis(LoggedInUserID, NewsList[currentNews].News_ID) == null)
			{
				btn_NewsFeed_MarkAsRead.isSelected = false;
				btn_NewsFeed_MarkAsRead.ImageSource = (BitmapImage)FindResource("icon_Unread");
			}
			else
			{
				btn_NewsFeed_MarkAsRead.isSelected = true;
				btn_NewsFeed_MarkAsRead.ImageSource = (BitmapImage)FindResource("icon_Read");
			}
		}
		private void UpdateViewMyBookmarksUI()
		{
			if (list_newsModelForItemsControls.Count <= 0)
			{
				Bookmark_NoBookmarksYet.Visibility = Visibility.Visible;
				Bookmark_ViewBookmarks.Visibility = Visibility.Hidden;
			}
			else
			{
				Bookmark_NoBookmarksYet.Visibility = Visibility.Hidden;
				Bookmark_ViewBookmarks.Visibility = Visibility.Visible;
			}
		}
		private void UpdateViewMyMarkedAsReadUI()
		{
			if (list_newsModelForItemsControls.Count <= 0)
			{
				MarkeAsRead_NoMarkedAsReadYet.Visibility = Visibility.Visible;
				MarkeAsRead_ViewMarkedAsRead.Visibility = Visibility.Hidden;
			}
			else
			{
				MarkeAsRead_NoMarkedAsReadYet.Visibility = Visibility.Hidden;
				MarkeAsRead_ViewMarkedAsRead.Visibility = Visibility.Visible;
			}
		}
		private void UpdateAdminPanelMenuSelectedButtonColorUI(CustomButton btn)
		{
			// unselected color on all buttons
			btn_OpenAddNewsTab.SetResourceReference(CustomButton.CusBtn_BackgroundProperty, "ButtonColor0_Normal");
			btn_OpenUpdateNewsTab.SetResourceReference(CustomButton.CusBtn_BackgroundProperty, "ButtonColor0_Normal");
			btn_OpenDeleteNewsTab.SetResourceReference(CustomButton.CusBtn_BackgroundProperty, "ButtonColor0_Normal");
			btn_OpenViewAllNewsTab.SetResourceReference(CustomButton.CusBtn_BackgroundProperty, "ButtonColor0_Normal");
			btn_OpenDeleteUserTab.SetResourceReference(CustomButton.CusBtn_BackgroundProperty, "ButtonColor0_Normal");
			btn_OpenViewAllUsersTab.SetResourceReference(CustomButton.CusBtn_BackgroundProperty, "ButtonColor0_Normal");

			// selected color on specified button
			btn.SetResourceReference(CustomButton.CusBtn_BackgroundProperty, "ButtonColor0_Hover");
		}
		private void UpdateAndDisplayNewsInNewsFeedUI()
		{
			img_NewsFeed.Source = ConvertByteArrayToImage(NewsList[currentNews].Image.ToArray());
			txt_NewsFeed_Headline.Text = NewsList[currentNews].Headline;
			txt_NewsFeed_News.Text = NewsList[currentNews].News;
			txt_NewsFeed_Category.Text = GetCategoryName(NewsList[currentNews].Category_ID);

			UpdateNewsFeedMarkAsReadButtonUI();
			UpdateNewsFeedBookMarkButtonUI();
		}
		private void UpdateNewsFeedNavigationButtonUI()
		{
			if (NewsList.Count <= 0)
			{
				NewsFeed_NewsNotAvailable.Visibility = Visibility.Visible;
				NewsFeed_ShowNews.Visibility = Visibility.Hidden;

				btn_NewsFeed_Previous.ImageSource = (BitmapImage)FindResource("icon_NoItemsLeft");
				btn_NewsFeed_Next.ImageSource = (BitmapImage)FindResource("icon_NoItemsLeft");
				return;
			}
			else
			{
				NewsFeed_NewsNotAvailable.Visibility = Visibility.Hidden;
				NewsFeed_ShowNews.Visibility = Visibility.Visible;
			}

			if (currentNews == 0)
				btn_NewsFeed_Previous.ImageSource = (BitmapImage)FindResource("icon_NoItemsLeft");

			if (currentNews != (NewsList.Count - 1))
				btn_NewsFeed_Next.ImageSource = (BitmapImage)FindResource("icon_Next");

			if (currentNews == (NewsList.Count - 1))
				btn_NewsFeed_Next.ImageSource = (BitmapImage)FindResource("icon_NoItemsLeft");

			if (currentNews > 0)
				btn_NewsFeed_Previous.ImageSource = (BitmapImage)FindResource("icon_Previous");
		}
		private void UpdateNewsListDataWithThisListAndOpenNewsFeedUI(List<NewsTable> listOfNews, bool isNotCategorySpecific = false)
		{
			if (isNotCategorySpecific == false)
				NewsList = listOfNews;

			currentNews = 0;

			if (NewsList.Count > 0)
			{
				UpdateAndDisplayNewsInNewsFeedUI();
				UpdateNewsFeedBookMarkButtonUI();
				UpdateNewsFeedMarkAsReadButtonUI();
			}

			UpdateNewsFeedNavigationButtonUI();
			NavigateToThisScreenUI(Screens.NEWS_FEED);
		}

		#endregion

		#endregion
	}

	public enum Screens
	{ 
		MAIN,
		NEWS_FEED,
		ADMIN_PANEL,
		MY_BOOKMARKS,
		MY_READ_HISTORY
	}

	public class NewsModelForItemsControl
	{ 
		public string Headline { get; set; }
		public string Category { get; set; }
		public string News_ID { get; set; }
		public BitmapImage Image { get; set; }

		public NewsModelForItemsControl(string Headline, string Category, string News_ID, BitmapImage Image)
		{
			this.Headline = Headline;
			this.Category = Category;
			this.News_ID = News_ID;
			this.Image = Image;
		}
	}

}
