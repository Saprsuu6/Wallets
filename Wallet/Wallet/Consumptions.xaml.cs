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
using Wallet.Classes;

namespace Wallet
{
    /// <summary>
    /// Interaction logic for Consumptions.xaml
    /// </summary>
    public partial class Consumptions : Window
    {
        public Consumptions()
        {
            InitializeComponent();

            DateSearch.SelectedDate = DateTime.UtcNow;
            DateStart.SelectedDate = DateTime.UtcNow;
            DateEnd.SelectedDate = DateTime.UtcNow;
        }

        public event EventHandler<EventArgs>? ascending = null;
        public event EventHandler<EventArgs>? descending = null;
        public event EventHandler<EventArgs>? reasonSerach = null;
        public event EventHandler<EventArgs>? moneySerach = null;
        public event EventHandler<EventArgs>? currencySerach = null;
        public event EventHandler<EventArgs>? dateSearch = null;
        public event EventHandler<EventArgs>? gapDateSearch = null;
        public event EventHandler<EventArgs>? apdateAllChecks = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Ascending.IsChecked == true)
                ascending?.Invoke(this, new EventArgs());
            else if (Descending.IsChecked == true)
                descending?.Invoke(this, new EventArgs());
        }

        private void ReasonSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ReasonSearch.Text.Length == 0)
                apdateAllChecks?.Invoke(this, new EventArgs());
            try
            {
                reasonSerach?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                ConsumptionsList.Items.Clear();
                NotFound.Visibility = Visibility.Visible;
            }
        }

        private void MoneySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            MoneySearch.Text = MoneySearch.Text.Trim();

            if (MoneySearch.Text.Length == 0)
                apdateAllChecks?.Invoke(this, new EventArgs());
            else
            {
                try
                {
                    if (Regular.CheckMoney(MoneySearch.Text))
                        moneySerach?.Invoke(this, EventArgs.Empty);
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    ConsumptionsList.Items.Clear();
                    NotFound.Visibility = Visibility.Visible;
                }
            }
        }

        private void CurrencySearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrencySearch.SelectedIndex == 0)
                apdateAllChecks?.Invoke(this, new EventArgs());
            else
            {
                try
                {
                    currencySerach?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                    ConsumptionsList.Items.Clear();
                    NotFound.Visibility = Visibility.Visible;
                }
            }
        }

        private void DateSearch_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dateSearch?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                ConsumptionsList.Items.Clear();
                NotFound.Visibility = Visibility.Visible;
            }
        }

        private void DateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                gapDateSearch?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                ConsumptionsList.Items.Clear();
                NotFound.Visibility = Visibility.Visible;
            }
        }
    }
}
