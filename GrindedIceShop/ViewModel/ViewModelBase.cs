using MaterialDesignThemes.Wpf;
using PropertyChanged;
using System;

namespace GrindedIceShop.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase
    {
        protected void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

    }
}
