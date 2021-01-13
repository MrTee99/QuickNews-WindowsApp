using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace Quick_News_App.Utils
{
	public class Utilities
	{
		public void BlurGridEffect(Grid MainGrid) => MainGrid.Effect = new BlurEffect();
		public void UndoAllGridEffects(Grid MainGrid) => MainGrid.Effect = null;

		public void UpdateLoginAndSignupButtonsUI(bool isLoggedIn, Custom_User_Controls.CustomButton loginBtn, Custom_User_Controls.CustomButton signupBtn)
		{
			if (isLoggedIn)
			{
				loginBtn.CusBtn_Content = "Logout";
				signupBtn.Visibility = Visibility.Hidden;
			}
			else
			{
				loginBtn.CusBtn_Content = "Login";
				signupBtn.Visibility = Visibility.Visible;
			}
		}

	}
}
