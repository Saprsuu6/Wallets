using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace Wallet.Classes
{
    internal class Presenter : IDisposable
    {
        private Person? person = null;
        private readonly MainWindow? mainWindow = null;
        private WalletsBase? wallets = null;

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            person = SaveLoad.LoadPerson();
            UpadateOwner();

            wallets = new WalletsBase(SaveLoad.LoadWallets());
            UpadateList();

            mainWindow.ownerChange += new EventHandler<EventArgs>(OwnerChange);
            mainWindow.addCard += new EventHandler<EventArgs>(AddCard);
            mainWindow.removeCard += new EventHandler<EventArgs>(RemoveCard);
            mainWindow.searchCard += new EventHandler<EventArgs>(SearchCard);
            mainWindow.updateAllCards += new EventHandler<EventArgs>(UpadateAllCards);
        }

        public void Dispose()
        {
            SaveLoad.SavePerson(person);
            SaveLoad.SaveWallets(wallets.Wallets);
        }

        #region OwnerChange
        private void OwnerChange(object? sender, EventArgs e)
        {
            PersonInfo? personInfo = sender as PersonInfo;
            personInfo.save += new EventHandler<EventArgs>(SaveOwner);

            personInfo.Name.Text = "Имя владельца";
            personInfo.Surename.Text = "Фамилия владельца";
            personInfo.PhoneNumber.Text = "Номер телефона владельца (+380)";
        }

        private void SaveOwner(object? sender, EventArgs e)
        {
            PersonInfo? personInfo = sender as PersonInfo;

            person = new Person(personInfo.Name.Text,
                personInfo.Surename.Text,
                personInfo.PhoneNumber.Text);

            UpadateOwner();
            UpadateOwnerInWallets();
        }

        private void UpadateOwner()
        {
            mainWindow.Name.Text = person.Name;
            mainWindow.Surename.Text = person.Surname;
            mainWindow.PhoneNumber.Text = person.Phone;
        }

        private void UpadateOwnerInWallets()
        {
            foreach (Wallet wallet in wallets)
                wallet.Owner = person;
        }
        #endregion

        #region AddCard
        private void AddCard(object? sender, EventArgs e)
        {
            if (mainWindow?.Name.Text == "" &&
                mainWindow?.Surename.Text == "" &&
                mainWindow?.PhoneNumber.Text == "")
                throw new ApplicationException("Добавьте владельца.");

            string? currency = mainWindow?.Currency.Text;
            Wallet wallet = new Wallet(person, currency);
            wallets?.AddWallet(wallet);

            UpadateList();
        }
        #endregion

        #region RemoveCard
        private void RemoveCard(object? sender, EventArgs e)
        {
            ListBoxItem? listBoxItem = mainWindow?.Cards.SelectedItem as ListBoxItem;
            UniformGrid? uniformGrid1 = listBoxItem?.Content as UniformGrid;
            UIElement? uIElement = uniformGrid1?.Children[0];
            TextBlock? textBlock = (uIElement as UniformGrid)?.Children[0] as TextBlock;

            string str = textBlock.Text.Substring(13);
            ulong number = ulong.Parse(str);
            wallets?.RemoveWallet(number);

            UpadateList();
        }
        #endregion

        #region SearchCard
        private void SearchCard(object? sender, EventArgs e)
        {
            try
            {
                ulong number = ulong.Parse(mainWindow.CardNumberSearch.Text);
               
                List<Wallet> list = new List<Wallet>();

                foreach (Wallet card in wallets)
                {
                    if(card.CardNumber.ToString().Contains(mainWindow.CardNumberSearch.Text))
                        list.Add(card);
                }

                if (list.Count == 0)
                    throw new Exception();

                mainWindow.Cards.Items.Clear();
                mainWindow.NotExists.Visibility = Visibility.Hidden;

                foreach (Wallet card in list)
                    Update(card);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        #endregion

        private void UpadateAllCards(object? sender, EventArgs e)
        {
            UpadateList();
            mainWindow.NotExists.Visibility = Visibility.Hidden;
        }

        private void UpadateList()
        {
            mainWindow?.Cards.Items.Clear();

            if (wallets?.Wallets.Count > 0)
            {
                mainWindow.EmptyList.Visibility = Visibility.Hidden;
                mainWindow.Search.IsEnabled = true;
            }
            else
            {
                mainWindow.EmptyList.Visibility = Visibility.Visible;
                mainWindow.Search.IsEnabled = false;
            }


            foreach (Wallet wallet in wallets)
            {
                Update(wallet);
            }
        }

        private void Update(Wallet wallet)
        {
            TextBlock number = new TextBlock();
            number.Text = "Номер карты: " + wallet.CardNumber.ToString();
            number.FontSize = 12;
            TextBlock money = new TextBlock();
            money.Text = "Сумма: " + wallet.Money.ToString() + " " + wallet.Currency;
            money.FontSize = 12;

            Button addMoney = new Button();
            addMoney.Content = "Положить деньги";
            addMoney.Margin = new Thickness(10, 1, 0, 1);
            Button transferMoney = new Button();
            transferMoney.Content = "Перевести деньги";
            transferMoney.Margin = new Thickness(10, 1, 0, 1);

            UniformGrid uniformGrid3 = new UniformGrid();
            uniformGrid3.Rows = 2;
            uniformGrid3.Children.Add(number);
            uniformGrid3.Children.Add(money);

            UniformGrid uniformGrid2 = new UniformGrid();
            uniformGrid2.Rows = 2;
            uniformGrid2.Children.Add(addMoney);
            uniformGrid2.Children.Add(transferMoney);

            UniformGrid uniformGrid1 = new UniformGrid();
            uniformGrid1.Columns = 2;
            uniformGrid1.Children.Add(uniformGrid3);
            uniformGrid1.Children.Add(uniformGrid2);

            ListBoxItem listBoxItem = new ListBoxItem();
            Brush brush = new SolidColorBrush(Color.FromRgb(186, 231, 235));
            listBoxItem.Background = brush;
            listBoxItem.Content = uniformGrid1;

            mainWindow?.Cards.Items.Add(listBoxItem);
        }
    }
}
