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
    /// Interaction logic for TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        private bool number;
        private bool money;

        public TransferMoney()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? transferMoney = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                transferMoney?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Cумма была успешно переведена.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            textBox.Text = textBox.Text.Trim();

            switch (textBox.Name)
            {
                case "Number":
                    if (Regular.CheckCardNumber(Number.Text))
                        number = true;
                    else
                        number = false;
                    break;
                case "Money":
                    if (Regular.CheckMoney(Money.Text))
                        money = true;
                    else
                        money = false;
                    break;
            }

            if (number && money)
                Transfer.IsEnabled = true;
            else
                Transfer.IsEnabled = false;
        }
    }
}
