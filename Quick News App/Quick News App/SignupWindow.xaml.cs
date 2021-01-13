﻿using System;
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
using Quick_News_App.Utils;

namespace Quick_News_App
{
	/// <summary>
	/// Interaction logic for SignupWindow.xaml
	/// </summary>
	public partial class SignupWindow : Window
	{
		private Grid MainGrid;
		private Utilities utilities = new Utilities();

		private string username;
		private string email;
		private string password;

		public SignupWindow(Grid MainGrid, Window OwnerWindow)
		{
			InitializeComponent();

			// Setting Windwo Owner
			this.Owner = OwnerWindow;

			// Bluring background Window
			this.MainGrid = MainGrid;
			utilities.BlurGridEffect(MainGrid);
		}

		private void btn_Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
			utilities.UndoAllGridEffects(MainGrid);
		}

		private void DragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

		private void btn_Signup_Click(object sender, RoutedEventArgs e)
		{
			username = input_SignupUsername.Text;
			email = input_SignupEmail.Text;
			password = input_SignupPassword.PasswordInput.Password;
		}
	}
}
