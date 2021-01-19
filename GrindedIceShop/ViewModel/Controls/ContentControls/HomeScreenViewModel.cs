using GalaSoft.MvvmLight.Command;
using GrindedIceShop.Models.Bills;
using GrindedIceShop.View.Controls.Dialogs.Bills;
using GrindedIceShop.ViewModel.Controls.Dialogs.Bills;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GrindedIceShop.ViewModel.Controls.ContentControls
{
    public class HomeScreenViewModel : ViewModelBase
    {
        private BillDetailViewModel _billDetailViewModel;
        private readonly bool _canExecuteCommand;

        public IEnumerable<Bill> Bills { get; set; }
        public ICommand AddNewBillCommand { get; }

        public HomeScreenViewModel()
        {
            this.LoadData();
            this._canExecuteCommand = true;
            this.AddNewBillCommand = new RelayCommand(ExecuteAddNewBillCommand, () => this._canExecuteCommand);
        }

        private void LoadData()
        {
            this.Bills = new ObservableCollection<Bill>();
        }

        #region Dialogs

        private async void ExecuteAddNewBillCommand()
        {
            this._billDetailViewModel = new BillDetailViewModel
            {
                Bill = new Bill()
            };

            var view = new BillDetailDialog
            {
                DataContext = this._billDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, MainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewBillClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void AddNewBillClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter && !parameter) return;


        }

        #endregion
    }
}
