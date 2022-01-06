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
    internal class Presenter
    {
        private Person? person = null;
        private readonly MainWindow? mainWindow = null;
        private WalletsBase? wallets = null;

        public Thickness Thinknes { get; private set; }

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            person = SaveLoad.LoadPerson();
            wallets = new WalletsBase(SaveLoad.LoadWallets());

            mainWindow.ownerChange += new EventHandler<EventArgs>(OwnerChange);
            mainWindow.addCard += new EventHandler<EventArgs>(AddCard);
            mainWindow.removeCard += new EventHandler<EventArgs>(RemoveCard);
            mainWindow.searchCard += new EventHandler<EventArgs>(SearchCard);
            mainWindow.updateAllCards += new EventHandler<EventArgs>(UpadateAllCards);
        }

        #region OwnerChange
        private void OwnerChange(object? sender, EventArgs e)
        {
            PersonInfo? personInfo = sender as PersonInfo;
            personInfo.save += new EventHandler<EventArgs>(SaveOwner);

            personInfo.Name.Text = person.Name;
            personInfo.Surename.Text = person.Surname;
            personInfo.PhoneNumber.Text = person.Phone;
        }

        private void SaveOwner(object? sender, EventArgs e)
        {
            PersonInfo? personInfo = sender as PersonInfo;

            person = new Person(personInfo.Name.Text,
                personInfo.Surename.Text,
                personInfo.PhoneNumber.Text);

            UpadateOwner();
        }

        private void UpadateOwner()
        {
            mainWindow.Name.Text = person.Name;
            mainWindow.Surename.Text = person.Surname;
            mainWindow.PhoneNumber.Text = person.Phone;
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
            UniformGrid? uniformGrid = listBoxItem?.Content as UniformGrid;
            TextBlock? textBlock = uniformGrid?.Children[0] as TextBlock;

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

            UniformGrid uniformGrid = new UniformGrid();
            uniformGrid.Rows = 2;
            uniformGrid.Children.Add(number);
            uniformGrid.Children.Add(money);

            ListBoxItem listBoxItem = new ListBoxItem();
            Brush brush = new SolidColorBrush(Color.FromRgb(186, 231, 235));
            listBoxItem.Background = brush;
            listBoxItem.Content = uniformGrid;

            mainWindow?.Cards.Items.Add(listBoxItem);
        }
    }
}
