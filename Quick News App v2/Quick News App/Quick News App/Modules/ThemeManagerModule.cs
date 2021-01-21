using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quick_News_App.Modules
{
	public sealed class ThemeManagerModule
	{
        #region Singleton Initialization

        private static ThemeManagerModule singleton = null;
        public static ThemeManagerModule Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new ThemeManagerModule();
                }
                return singleton;
            }
        }

        #endregion

        public Themes currentlySelectedTheme { get; set; }
        private ResourceDictionary currentTheme;
        private Collection<ResourceDictionary> appResources = App.Current.Resources.MergedDictionaries;

        public void ChangeThemeToThisTheme(Themes theme)
        {
            if (currentTheme != null)
                appResources.Remove(currentTheme);

            currentTheme = (ResourceDictionary)App.LoadComponent(new Uri(GetThemeNameWithCompleteLocation(theme), UriKind.Relative));

            if (currentTheme != null)
                appResources.Add(currentTheme);
        }

        #region Internally Used Method (Private)

        private string GetThemeNameWithCompleteLocation(Themes theme)
        {
            if(theme == Themes.LIGHT_THEME)
                return "Resource Dictionaries/RD_LightTheme.xaml";

            return "Resource Dictionaries/RD_DarkTheme.xaml";
        }

		#endregion
	}

	public enum Themes
    { 
        LIGHT_THEME,
        DARK_THEME
    }

}
