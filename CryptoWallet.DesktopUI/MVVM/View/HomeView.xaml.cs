using CryptoWallet.DesktopUI.Model;
using CryptoWallet.DesktopUI.MVVM.Model;
using CryptoWallet.DesktopUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace CryptoWallet.DesktopUI.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private DataTable _table = new DataTable();

        public HomeView()
        {
            InitializeComponent();

            SetBalanceUser();
        }

        private async void SetBalanceUser()
        {
            var balanceService = new BalanceService();

            var response = await balanceService.GetBalance<ResponseDto>(2);

            var balances = JsonConvert.DeserializeObject<IEnumerable<UserBalanceDto>>(Convert.ToString(response.Result));

            ListViewBalance.DataContext = _table;

            _table.Columns.Clear();
            _table.Rows.Clear();

            _table.Columns.Add("Coin");
            _table.Columns.Add("Count");

            int rowCount = 0;
            foreach(var balanceRow in balances?.Select(x => new Balance { Coin = x.Coin, Count = x.Count }))
            {
                _table.Rows.Add(_table.NewRow());
                _table.Rows[rowCount]["Coin"] = balanceRow.Coin;
                _table.Rows[rowCount]["Count"] = balanceRow.Count;

                rowCount++;
            }

            var gv = new GridView();

            foreach (DataColumn item in _table.Columns)
            {
                GridViewColumn gv_col = new GridViewColumn
                {
                    Header = item.ColumnName,
                    DisplayMemberBinding = new Binding(item.ColumnName)
                };

                gv.Columns.Add(gv_col);
            }

            ListViewBalance.View = gv;

            ListViewBalance.Items.Refresh();
        }
    }
}
