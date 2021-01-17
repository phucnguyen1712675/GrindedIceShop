using GalaSoft.MvvmLight.Command;
using MaterialDesignExtensions.Model;
using MaterialDesignExtensions.Themes;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Input;

namespace GrindedIceShop.ViewModel.Controls
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _canExecuteMyCommand;
        public static MainWindowViewModel Instance;
        public string Title { get; }
        public string Identifier { get; }
        public bool IsNavigationDrawerOpen { get; set; }
        public List<INavigationItem> NavigationItems { get; set; }
        public INavigationItem SelectedNavigationItem { get; set; }
        public bool IsChecked { get; set; }
        public ICommand DarkModeCommand { get; }

        public MainWindowViewModel()
        {
            Instance = this;
            this._canExecuteMyCommand = true;
            Title = "Grinded Ice Shop";
            Identifier = "mainWindowDialogHost";
            IsNavigationDrawerOpen = false;
            var value = ConfigurationManager.AppSettings["IsDarkMode"];
            this.IsChecked = bool.Parse(value);
            ModifyTheme(this.IsChecked);
            this.DarkModeCommand = new RelayCommand(ExecuteDarkModeModify, () => this._canExecuteMyCommand);
            /*NavigationItems = new List<INavigationItem>()
            {
                new FirstLevelNavigationItem() { Label = "Trang chủ", Icon = PackIconKind.Home, NavigationItemSelectedCallback = _ => new HomeScreenViewModel(), IsSelected = true },
                new FirstLevelNavigationItem() { Label = "Thống kê", Icon = PackIconKind.CashUsd, NavigationItemSelectedCallback = _ => new StatisticsViewModel()},
                new FirstLevelNavigationItem() { Label = "Thêm đơn hàng", Icon = PackIconKind.Cart, NavigationItemSelectedCallback = _ => CreateOrderScreenViewModel.Instance }
            };
            SelectedNavigationItem = NavigationItems[0];*/
        }

        private void ExecuteDarkModeModify()
        {
            ModifyTheme(this.IsChecked);
            SaveThemeMode(this.IsChecked);
        }

        private static void ModifyTheme(bool isDarkTheme)
        {
            var paletteHelper = new MaterialDesignThemes.Wpf.PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDarkTheme ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }

        private void SaveThemeMode(bool isDarkTheme)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IsDarkMode"].Value = isDarkTheme.ToString();
            config.Save(ConfigurationSaveMode.Minimal);
        }
    }
}
