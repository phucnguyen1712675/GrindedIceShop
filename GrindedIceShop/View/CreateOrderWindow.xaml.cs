using MaterialDesignExtensions.Controls;
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

namespace GrindedIceShop.View
{
    /// <summary>
    /// Interaction logic for CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : MaterialWindow
    {
        public CreateOrderWindow()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
           /* var testGrinded = GrindedIceMenuListView.SelectedItem as string;
            var testBeve = BeverageMenuListView.SelectedItem as string;
            List<string> testTop = new List<string>();
            foreach (var item in ToppingMenuListView.)
            {
                if((bool)(item as CheckBox).IsChecked)
                    testTop.Add(item.ToString());
            }*/
        }
    }
}
