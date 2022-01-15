using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wallet.Classes;

namespace Wallet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Presenter? presenter = null;
        
        private bool reason;
        private bool money;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        public event EventHandler<EventArgs>? ownerChange = null;
        public event EventHandler<EventArgs>? addCard = null;
        public event EventHandler<EventArgs>? removeCard = null;
        public event EventHandler<EventArgs>? searchCard = null;
        public event EventHandler<EventArgs>? updateAllCards = null;
        public event EventHandler<EventArgs>? addSum = null;
        public event EventHandler<EventArgs>? trunsferMoney = null;
        public event EventHandler<EventArgs>? pay = null;
        public event EventHandler<EventArgs>? consimptionsList = null;
        public event EventHandler<EventArgs>? statistic = null;

        private void SelectCard(Button? button)
        {
            UniformGrid? parrent1 = button?.Parent as UniformGrid;
            UniformGrid? parrent2 = parrent1?.Parent as UniformGrid;
            ListBoxItem? listBoxItem = parrent2?.Parent as ListBoxItem;

            listBoxItem.IsSelected = true;
        }

        private void Button_Click(object sender, RoutedEventArgs? e)
        {
            Effect = new BlurEffect();

            try
            {
                PersonInfo personInfo = new PersonInfo();
                ownerChange?.Invoke(personInfo, new EventArgs());
                personInfo.Owner = this;
                personInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Effect = null;
        }

        public void AddMoney_Click(object sender, RoutedEventArgs? e)
        {
            SelectCard(sender as Button);

            Effect = new BlurEffect();

            try
            {
                AddMoney addMoney = new AddMoney();
                addSum?.Invoke(addMoney, new EventArgs());
                addMoney.Owner = this;
                addMoney.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Effect = null;
        }

        public void TransferMoney_Click(object sender, RoutedEventArgs? e)
        {
            SelectCard(sender as Button);

            Effect = new BlurEffect();

            try
            {
                TransferMoney transfer = new TransferMoney();
                trunsferMoney?.Invoke(transfer, new EventArgs());
                transfer.Owner = this;
                transfer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Effect = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Button_Click(this, null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                addCard?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Карта была добавлена.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Remove.IsEnabled = true;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                removeCard?.Invoke(this, EventArgs.Empty);
                Remove.IsEnabled = false;
                MessageBox.Show("Карта была удалена.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Effect = new BlurEffect();

            Consumptions consumptions = new Consumptions();
            consimptionsList?.Invoke(consumptions, new EventArgs());
            consumptions.Owner = this;
            consumptions.ShowDialog();

            Effect = null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Effect = new BlurEffect();

            try
            {
                Statistic statistic = new Statistic();
                this.statistic?.Invoke(statistic, new EventArgs());
                statistic.Owner = this;
                statistic.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Effect = null;
        }

        private void CardNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardNumberSearch.Text = CardNumberSearch.Text.Trim();

            if (CardNumberSearch.Text.Length == 0)
                updateAllCards?.Invoke(this, new EventArgs());
            else
            {
                try
                {
                    if (Regular.CheckCardNumber(CardNumberSearch.Text))
                        searchCard?.Invoke(this, new EventArgs());
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    Cards.Items.Clear();
                    NotExists.Visibility = Visibility.Visible;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            presenter?.Dispose();
        }

        private void Reason_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            if (textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void Reason_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            if (textBox.Text == "")
            {
                textBox.Foreground = Brushes.Gray;

                if (textBox.Name == "Reason")
                    textBox.Text = "Куда вы хотите потратить деньги";
                else if (textBox.Name == "Money")
                    textBox.Text = "Введите сумму";
            }
        }

        private void Reason_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Reason.Text.Length > 0)
                reason = true;
            else 
                reason = false;

            EnableDisabePay();
        }

        private void Money_TextChanged(object sender, TextChangedEventArgs e)
        {
            Money.Text = Money.Text.Trim();

            if (Regular.CheckMoney(Money.Text))
                money = true;
            else
                money = false;

            EnableDisabePay();
        }

        private void EnableDisabePay()
        {
            if (reason && money)
                Pay.IsEnabled = true;
            else
                Pay.IsEnabled = false;
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Хотите ли вы продолжить оплату?", "",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    pay?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Оплата прошла успешно.", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    Reason.Text = "";
                    Money.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
