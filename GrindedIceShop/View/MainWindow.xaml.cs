using GrindedIceShop.ViewModel.Controls;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;

namespace GrindedIceShop.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void NavigationItemSelectedHandler(object sender, NavigationItemSelectedEventArgs args)
           => SelectNavigationItem(args.NavigationItem);

        public void SetContentControl(object newContent)
            => contentControl.Content = newContent;

        private void SelectNavigationItem(INavigationItem navigationItem)
        {
            if (navigationItem != null)
            {
                object newContent = navigationItem.NavigationItemSelectedCallback(navigationItem);

                if (contentControl.Content == null || contentControl.Content.GetType() != newContent.GetType())
                {
                    SetContentControl(newContent);
                }
            }
            else
            {
                SetContentControl(null);
            }

            if (appBar != null)
            {
                appBar.IsNavigationDrawerOpen = false;
            }
        }
    }
}
