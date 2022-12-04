using CryptoWallet.DesktopUI.Model;
using CryptoWallet.DesktopUI.MVVM.Model;
using CryptoWallet.DesktopUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CryptoWallet.DesktopUI.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        private DataTable _table = new DataTable();

        public HistoryView()
        {
            InitializeComponent();

            SetHistory();
        }

        private async void SetHistory()
        {
            var transactionService = new TransactionService();

            var response = await transactionService.GetHistory<ResponseDto>(6);

            var history = JsonConvert.DeserializeObject<IEnumerable<TransactionDto>>(Convert.ToString(response.Result));

            ListViewBalance.DataContext = _table;

            _table.Columns.Clear();
            _table.Rows.Clear();

            _table.Columns.Add("SenderId");
            _table.Columns.Add("RecipientId");
            _table.Columns.Add("Coin");
            _table.Columns.Add("Count");
            _table.Columns.Add("Time");
            _table.Columns.Add("Result");

            int rowCount = 0;
            foreach (var historyRow in history?.Select(x => 
                new Transaction { SenderId = x.SenderId, RecipientId = x.RecipientId, Coin = x.Coin, Count = x.Count, Result = x.Result, Time = x.Time }))
            {
                _table.Rows.Add(_table.NewRow());
                _table.Rows[rowCount]["SenderId"] = historyRow.SenderId;
                _table.Rows[rowCount]["RecipientId"] = historyRow.RecipientId;
                _table.Rows[rowCount]["Coin"] = historyRow.Coin;
                _table.Rows[rowCount]["Count"] = historyRow.Count;
                _table.Rows[rowCount]["Time"] = historyRow.Time;
                _table.Rows[rowCount]["Result"] = historyRow.Result;

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
