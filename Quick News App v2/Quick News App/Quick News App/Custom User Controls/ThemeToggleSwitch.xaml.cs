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
using Quick_News_App.Modules;

namespace Quick_News_App.Custom_User_Controls
{
	public partial class ThemeToggleSwitch : UserControl
	{
		Thickness LeftSide = new Thickness(-65, 0, 0, 1.5);
		Thickness RightSide = new Thickness(0, 0, -65, 1.5);
		SolidColorBrush off_LightTheme = (SolidColorBrush)(new BrushConverter().ConvertFrom("#115EBA"));
		SolidColorBrush on_DarkTheme = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E94560"));

		public bool isToggled { get; private set; }

		public ThemeToggleSwitch()
		{
			InitializeComponent();
        }

        public void InitializeToggleSwitch(Themes theme)
        {
            this.isToggled = (theme == Themes.LIGHT_THEME) ? true : false;
            ToggleSwitch();
        }

        private void Switch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => ToggleSwitch();
        private void ToggleSwitch()
        {
            if (!isToggled)
            {
                ThemeManagerModule.Singleton.ChangeThemeToThisTheme(Themes.DARK_THEME);
                Back.Fill = on_DarkTheme;
                isToggled = true;
                Dot.Margin = RightSide;
                txt_LightMode.Visibility = Visibility.Visible;
                txt_DarkMode.Visibility = Visibility.Hidden;
            }
            else
            {
                ThemeManagerModule.Singleton.ChangeThemeToThisTheme(Themes.LIGHT_THEME);
                Back.Fill = off_LightTheme;
                isToggled = false;
                Dot.Margin = LeftSide;
                txt_LightMode.Visibility = Visibility.Hidden;
                txt_DarkMode.Visibility = Visibility.Visible;
            }
        }
    }
}
