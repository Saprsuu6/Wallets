﻿using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
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
        private ConsumptionBase? consumptions = null;

        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            person = SaveLoad.LoadPerson();
            UpadateOwner();

            wallets = new WalletsBase(SaveLoad.LoadWallets());
            UpadateListCards();

            consumptions = new ConsumptionBase(SaveLoad.LoadConsumptions());

            if (wallets.Wallets.Count > 0)
            {
                Wallet wallet = wallets.Wallets[wallets.Wallets.Count - 1];
                Wallet.number = wallet.CardNumber;
            }

            mainWindow.ownerChange += new EventHandler<EventArgs>(OwnerChange);
            mainWindow.addCard += new EventHandler<EventArgs>(AddCard);
            mainWindow.removeCard += new EventHandler<EventArgs>(RemoveCard);
            mainWindow.searchCard += new EventHandler<EventArgs>(SearchCard);
            mainWindow.updateAllCards += new EventHandler<EventArgs>(UpadateAllCards);
            mainWindow.addSum += new EventHandler<EventArgs>(AddMoneyToCard);
            mainWindow.trunsferMoney += new EventHandler<EventArgs>(TransferMoneyToCard);
            mainWindow.pay += new EventHandler<EventArgs>(Pay);
            mainWindow.consimptionsList += new EventHandler<EventArgs>(UpdateConsumptionsList);
            mainWindow.statistic += new EventHandler<EventArgs>(UpdateStatistic);
        }

        public void Dispose()
        {
            SaveLoad.SavePerson(person);
            SaveLoad.SaveWallets(wallets.Wallets);
            SaveLoad.SaveConsumptions(consumptions.Consumptions);
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

            UpadateListCards();
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

            UpadateListCards();
        }
        #endregion

        #region SearchCard
        private void SearchCard(object? sender, EventArgs e)
        {
            ulong number = ulong.Parse(mainWindow.CardNumberSearch.Text);

            List<Wallet> list = new List<Wallet>();

            foreach (Wallet card in wallets)
            {
                if (card.CardNumber.ToString().Contains(mainWindow.CardNumberSearch.Text))
                    list.Add(card);
            }

            if (list.Count == 0)
                throw new Exception();

            mainWindow.Cards.Items.Clear();
            mainWindow.NotExists.Visibility = Visibility.Hidden;

            foreach (Wallet card in list)
                UpdateCards(card);
        }
        #endregion

        #region AddMoney

        private void AddMoneyToCard(object? sender, EventArgs e)
        {
            AddMoney? addMoney = sender as AddMoney;

            addMoney.Money.Text = "Введите сумму (X или X.X)";
            addMoney.addMoney += new EventHandler<EventArgs>(AddToCard);
        }

        private void AddToCard(object? sender, EventArgs e)
        {
            AddMoney? addMoney = sender as AddMoney;

            double money = double.Parse(addMoney.Money.Text);

            ListBoxItem? listBoxItem = mainWindow?.Cards.SelectedItem as ListBoxItem;
            UniformGrid? uniformGrid1 = listBoxItem?.Content as UniformGrid;
            UIElement? uIElement = uniformGrid1?.Children[0];
            TextBlock? textBlock = (uIElement as UniformGrid)?.Children[0] as TextBlock;

            string str = textBlock.Text.Substring(13);
            ulong number = ulong.Parse(str);

            Wallet wallet = wallets[number];

            if (wallet.Currency != "UAH" && addMoney.Currency.Text != "UAH")
            {
                string currency1 = addMoney.Currency.Text + "_UAH";
                Convert(ref money, currency1);

                string currency2 = "UAH_" + wallet.Currency;
                Convert(ref money, currency2);
            }
            else if (wallet.Currency != "UAH" || addMoney.Currency.Text != "UAH")
            {
                string currency = addMoney.Currency.Text + "_" + wallet.Currency;
                Convert(ref money, currency);
            }

            money = Math.Round(money, 2);
            wallet.AddMoney(money);
            UpadateListCards();
        }

        private void Convert(ref double money, string currency)
        {
            foreach (Converter converter in wallets.Converters)
            {
                if (converter.Naming == currency)
                {
                    money = converter.Convert(money);
                    break;
                }
            }
        }
        #endregion

        #region TransferMoney
        private void TransferMoneyToCard(object? sender, EventArgs e)
        {
            if (wallets?.Wallets.Count <= 1)
                throw new ApplicationException("У вас всего лишь одна карта.");

            if (wallets?.Wallets[mainWindow.Cards.SelectedIndex].Money <= 0)
                throw new ApplicationException("На этой карточке нет денег.");

            TransferMoney? transfer = sender as TransferMoney;

            transfer.Number.Text = "Номер карточки";
            transfer.Money.Text = "Сумма перевода" + " (" +
                wallets?.Wallets[mainWindow.Cards.SelectedIndex].Currency + ")";

            transfer.transferMoney += new EventHandler<EventArgs>(Transfer);
        }

        private void Transfer(object? sender, EventArgs e)
        {
            TransferMoney? transfer = sender as TransferMoney;

            Wallet? walletDestination = null;
            try
            {
                ulong number = ulong.Parse(transfer.Number.Text);
                foreach (Wallet wallet in wallets)
                {
                    if (wallet.CardNumber == number)
                    {
                        walletDestination = wallet;
                        break;
                    }
                }

                if (walletDestination == null)
                    throw new ApplicationException("Карты с таким номером не существует.");
            }
            catch (Exception)
            {
                throw;
            }
            
            Wallet walletSender = wallets.Wallets[mainWindow.Cards.SelectedIndex];
            double money = double.Parse(transfer.Money.Text);

            if (money > walletSender.Money)
                throw new ApplicationException("Сумма запроса превышает сумму денег на карточке.");

            walletSender.GetMoney(money);

            if (walletSender.Currency != "UAH" && walletDestination.Currency != "UAH")
            {
                string currency1 = walletSender.Currency + "_UAH";
                Convert(ref money, currency1);

                string currency2 = "UAH_" + walletDestination.Currency;
                Convert(ref money, currency2);
            }
            else if (walletSender.Currency != "UAH" || walletDestination.Currency!= "UAH")
            {
                string currency = walletSender.Currency + "_" + walletDestination.Currency;
                Convert(ref money, currency);
            }

            money = Math.Round(money, 2);
            walletDestination.AddMoney(money);
            UpadateListCards();
        }
        #endregion

        #region Pay
        private void Pay(object? sender, EventArgs e)
        {
            if (mainWindow.Cards.SelectedIndex == -1)
                throw new ApplicationException("Выберите карточку.");

            Wallet wallet = wallets.Wallets[mainWindow.Cards.SelectedIndex];
            double money = double.Parse(mainWindow.Money.Text);

            if (money > wallet.Money)
                throw new ApplicationException("Недостаточно денег на счету.");

            wallet.GetMoney(money);
            CreateConsumption(mainWindow.Reason.Text.Trim(),
                money, wallet.Currency);

            UpadateListCards();
        }

        private void CreateConsumption(string reason, double money, string currency)
        {
            Consumption consumption = new Consumption(reason, money, currency, DateTime.UtcNow);
            consumptions.AddConsumption(consumption);
        }
        #endregion

        #region UpdatingsCards
        private void UpadateAllCards(object? sender, EventArgs e)
        {
            UpadateListCards();
            mainWindow.NotExists.Visibility = Visibility.Hidden;
        }

        private void UpadateListCards()
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
                UpdateCards(wallet);
            }
        }

        private void UpdateCards(Wallet wallet)
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
            addMoney.Click += new RoutedEventHandler(mainWindow.AddMoney_Click);
            Button transferMoney = new Button();
            transferMoney.Content = "Перевести деньги";
            transferMoney.Margin = new Thickness(10, 1, 0, 1);
            transferMoney.Click += new RoutedEventHandler(mainWindow.TransferMoney_Click);

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
        #endregion

        #region UpdationConsumptions
        private void UpdateConsumptionsList(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            consumptionsWindow.ascending += new EventHandler<EventArgs>(Ascending);
            consumptionsWindow.descending += new EventHandler<EventArgs>(Descending);
            consumptionsWindow.reasonSerach += new EventHandler<EventArgs>(ReasonSearch);
            consumptionsWindow.moneySerach += new EventHandler<EventArgs>(MoneySearch);
            consumptionsWindow.currencySerach += new EventHandler<EventArgs>(CurrencySearch);
            consumptionsWindow.dateSearch += new EventHandler<EventArgs>(DateSearch);
            consumptionsWindow.gapDateSearch += new EventHandler<EventArgs>(GapDateSearch);
            consumptionsWindow.apdateAllChecks += new EventHandler<EventArgs>(ApdateAllChecks);

            if (consumptions?.Consumptions.Count == 0)
            {
                consumptionsWindow.EmptyList.Visibility = Visibility.Visible;
                consumptionsWindow.Ascending.IsEnabled = false;
                consumptionsWindow.Descending.IsEnabled = false;
                consumptionsWindow.Search.IsEnabled = false;
                return;
            }
            else if (consumptions?.Consumptions.Count > 0)
            {
                consumptionsWindow.EmptyList.Visibility = Visibility.Hidden;
                consumptionsWindow.Ascending.IsEnabled = true;
                consumptionsWindow.Descending.IsEnabled = true;
                consumptionsWindow.Descending.IsChecked = true;
                consumptionsWindow.Search.IsEnabled = true;
            }
        }

        private void ApdateAllChecks(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            Descending(consumptionsWindow, new EventArgs());
            consumptionsWindow.NotFound.Visibility = Visibility.Hidden;
        }

        private void ReasonSearch(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            string reason = consumptionsWindow.ReasonSearch.Text;

            List<Consumption> consumptions = new List<Consumption>();
            foreach (Consumption consumption in this.consumptions)
            {
                if (consumption.Reason.Contains(reason))
                    consumptions.Add(consumption);
            }

            UpadeteNotFound(consumptions, consumptionsWindow);
        }

        private void MoneySearch(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            double money = double.Parse(consumptionsWindow.MoneySearch.Text);

            List<Consumption> consumptions = new List<Consumption>();
            foreach (Consumption consumption in this.consumptions)
            {
                if (consumption.Money == money)
                    consumptions.Add(consumption);
            }

            UpadeteNotFound(consumptions, consumptionsWindow);
        }

        private void CurrencySearch(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            string currency = consumptionsWindow.CurrencySearch.SelectedValue.ToString();
            int index = currency.IndexOf(':');
            currency = currency.Substring(index + 2);

            List<Consumption> consumptions = new List<Consumption>();
            foreach (Consumption consumption in this.consumptions)
            {
                if (consumption.Currency == currency)
                    consumptions.Add(consumption);
            }

            UpadeteNotFound(consumptions, consumptionsWindow);
        }

        private void DateSearch(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            DateTime? date = consumptionsWindow.DateSearch.SelectedDate;

            List<Consumption> consumptions = new List<Consumption>();
            foreach (Consumption consumption in this.consumptions)
            {
                if (consumption.Date.Year == date.Value.Year
                    && consumption.Date.Month == date.Value.Month
                    && consumption.Date.Day == date.Value.Day)
                    consumptions.Add(consumption);
            }

            UpadeteNotFound(consumptions, consumptionsWindow);
        }

        private void GapDateSearch(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            DateTime? dateStart = consumptionsWindow.DateStart.SelectedDate;
            DateTime? dateEnd = consumptionsWindow.DateEnd.SelectedDate;

            List<Consumption> consumptions = new List<Consumption>();
            foreach (Consumption consumption in this.consumptions)
            {
                if (consumption.Date.Year >= dateStart.Value.Year && consumption.Date.Year <= dateEnd.Value.Year
                    && consumption.Date.Month >= dateStart.Value.Month && consumption.Date.Month <= dateEnd.Value.Month
                    && consumption.Date.Day >= dateStart.Value.Day && consumption.Date.Day <= dateEnd.Value.Day)
                    consumptions.Add(consumption);
            }

            UpadeteNotFound(consumptions, consumptionsWindow);
        }

        private void UpadeteNotFound(List<Consumption> consumptions, Consumptions? consumptionsWindow)
        {
            if (consumptions.Count < 1)
                throw new ApplicationException();

            consumptionsWindow.ConsumptionsList.Items.Clear();
            consumptionsWindow.NotFound.Visibility = Visibility.Hidden;

            foreach (Consumption consumption in consumptions)
            {
                UpdateConsumptions(consumption, consumptionsWindow);
            }
        }

        private void Descending(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            if (consumptionsWindow.ConsumptionsList.Items.Count > 0)
                consumptionsWindow?.ConsumptionsList.Items.Clear();

            foreach (Consumption consumption in consumptions)
            {
                UpdateConsumptions(consumption, consumptionsWindow);
            }
        }

        private void Ascending(object? sender, EventArgs e)
        {
            Consumptions? consumptionsWindow = sender as Consumptions;

            consumptionsWindow?.ConsumptionsList.Items.Clear();
            List<Consumption> sortConsumptions = consumptions.Clone();
            sortConsumptions.Sort(new Consumption.Ascending());

            foreach (Consumption consumption in sortConsumptions)
            {
                UpdateConsumptions(consumption, consumptionsWindow);
            }
        }

        private void UpdateConsumptions(Consumption consumption, Consumptions? consumptionsWindow)
        {
            TextBlock reason = new TextBlock();
            reason.Text = consumption.Reason;
            TextBlock money = new TextBlock();
            money.Text = "Сумма: " + consumption.Money.ToString() + " " + consumption.Currency;
            TextBlock date = new TextBlock();
            date.Text = consumption.Date.ToString();

            UniformGrid uniformGrid = new UniformGrid();
            uniformGrid.Rows = 3;
            uniformGrid.Children.Add(reason);
            uniformGrid.Children.Add(money);
            uniformGrid.Children.Add(date);

            ListBoxItem listBoxItem = new ListBoxItem();
            Brush brush = new SolidColorBrush(Color.FromRgb(210, 186, 236));
            listBoxItem.Background = brush;
            listBoxItem.Content = uniformGrid;

            consumptionsWindow?.ConsumptionsList.Items.Add(listBoxItem);
        }
        #endregion

        #region
        private void UpdateStatistic(object? sender, EventArgs e)
        {
            if (consumptions.Consumptions.Count < 1)
                throw new ApplicationException("У вас нет затрат");

            Statistic? statistic = sender as Statistic;

            statistic.year += new EventHandler<EventArgs>(UpdateForYear);
            statistic.month += new EventHandler<EventArgs>(UpdateForMonth);

            statistic.Chart.Series.Clear();
            Init(statistic);
        }

        private void Init(Statistic? statistic)
        {
            statistic.Year.Text = DateTime.Now.Year.ToString();
            statistic.Month.Text = DateTime.Now.Month.ToString();
        }

        private void UpdateForMonth(object? sender, EventArgs e)
        {
            Statistic? statistic = sender as Statistic;
            UpadateVisible(statistic);

            int year = int.Parse(statistic.Year.Text);
            int month = int.Parse(statistic.Month.Text);

            List<Consumption> currentConsumptions = new List<Consumption>();

            foreach (Consumption consumption in consumptions)
            {
                if (consumption.Date.Month == month)
                    currentConsumptions.Add(consumption);
            }

            if (currentConsumptions.Count < 1)
                throw new ApplicationException();

            List<LineSeries> charlesSeries = new List<LineSeries>()
            {
                AmountPerDay(year, month, currentConsumptions),
                SumPerDay(year, month, currentConsumptions),
            };

            GenerateStatistic(statistic, charlesSeries);
        }

        private LineSeries SumPerDay(int year, int month, List<Consumption> currentConsumptions)
        {
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            int amountDays = DateTime.DaysInMonth(year, month);
            double sumPerDay = 0;

            for (int i = 0; i <= amountDays; i++)
            {
                List<Consumption> consumptionsPerDay = new List<Consumption>();
                foreach (Consumption consumption in currentConsumptions)
                {
                    if (consumption.Date.Day == i)
                        consumptionsPerDay.Add(consumption);
                }

                foreach (Consumption consumption in consumptionsPerDay)
                    sumPerDay += consumption.Money;

                points.Add(new ObservablePoint(i, sumPerDay));
                sumPerDay = 0;
            }

            return new LineSeries
            {
                Title = "Сумма затрат за день",
                Values = points
            };
        }

        private LineSeries AmountPerDay(int year, int month, List<Consumption> currentConsumptions)
        {
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            int amountDays = DateTime.DaysInMonth(year, month);
            int amountPerDay = 0;

            for (int i = 0; i <= amountDays; i++)
            {
                foreach (Consumption consumption in currentConsumptions)
                {
                    if (consumption.Date.Day == i)
                        amountPerDay++;
                }

                points.Add(new ObservablePoint(i, amountPerDay));
                amountPerDay = 0;
            }

            return new LineSeries
            {
                Title = "Колличество чеков за день",
                Values = points
            };
        }

        private void UpdateForYear(object? sender, EventArgs e)
        {
            Statistic? statistic = sender as Statistic;
            UpadateVisible(statistic);

            int year = int.Parse(statistic.Year.Text);

            List<Consumption> currentConsumptions = new List<Consumption>();

            foreach (Consumption consumption in consumptions)
            {
                if (consumption.Date.Year == year)
                    currentConsumptions.Add(consumption);
            }

            if (currentConsumptions.Count < 1)
                throw new ApplicationException();

            List<LineSeries> charlesSeries = new List<LineSeries>()
            {
                AmountPerMonth(currentConsumptions),
                SumPerMonth(currentConsumptions),
            };

            GenerateStatistic(statistic, charlesSeries);
        }

        private LineSeries AmountPerMonth(List<Consumption> currentConsumptions)
        {
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            int amountPerMonth = 0;

            for (int i = 0; i <= 12; i++)
            {
                foreach (Consumption consumption in currentConsumptions)
                {
                    if (consumption.Date.Month == i)
                        amountPerMonth++;
                }

                points.Add(new ObservablePoint(i, amountPerMonth));
                amountPerMonth = 0;
            }

            return new LineSeries
            {
                Title = "Колличество чеков за день",
                Values = points
            };
        }

        private LineSeries SumPerMonth(List<Consumption> currentConsumptions)
        {
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            double sumPerMonth = 0;

            for (int i = 0; i <= 12; i++)
            {
                List<Consumption> consumptionsPerMonth = new List<Consumption>();
                foreach (Consumption consumption in currentConsumptions)
                {
                    if (consumption.Date.Month == i)
                        consumptionsPerMonth.Add(consumption);
                }

                foreach (Consumption consumption in consumptionsPerMonth)
                    sumPerMonth += consumption.Money;

                points.Add(new ObservablePoint(i, sumPerMonth));
                sumPerMonth = 0;
            }

            return new LineSeries
            {
                Title = "Сумма затрат за день",
                Values = points
            };
        }

        private void GenerateStatistic(Statistic? statistic, List<LineSeries> charlesSeries)
        {
            SeriesCollection series = new SeriesCollection();

            foreach (LineSeries lineSeries in charlesSeries)
                series.Add(lineSeries);

            statistic.Chart.Series = series;
        }

        private void UpadateVisible(Statistic? statistic)
        {
            statistic.Chart.Visibility = Visibility.Visible;
            statistic.NotExists.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
