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
    /// Interaction logic for AddMoney.xaml
    /// </summary>
    public partial class AddMoney : Window
    {
        public AddMoney()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? addMoney = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addMoney?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Cумма была успешно переведена.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Money_TextChanged(object sender, TextChangedEventArgs e)
        {
            Money.Text = Money.Text.Trim();

            if (Regular.CheckMoney(Money.Text))
                Add.IsEnabled = true;
            else
                Add.IsEnabled = false;
        }
    }
}
