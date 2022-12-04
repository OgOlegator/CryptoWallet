using CryptoWallet.DesktopUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.DesktopUI.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public enum Pages
        {
            Home,
            History,
            Transfer
        }

        public HomeViewModel HomeView { get; set; }

        public HistoryViewModel HistoryView { get; set; }

        public TransferViewModel TransferView { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ChangePage(Pages.History); 
        }

        public void ChangePage(Pages page)
        {
            switch(page)
            {
                case Pages.Home:
                    HomeView = new HomeViewModel();
                    CurrentView = HomeView;
                    break;
                case Pages.History:
                    HistoryView = new HistoryViewModel();
                    CurrentView = HistoryView;
                    break;
                case Pages.Transfer:
                    TransferView = new TransferViewModel();
                    CurrentView = TransferView;
                    break;
                    
            }
        }

    }
}
