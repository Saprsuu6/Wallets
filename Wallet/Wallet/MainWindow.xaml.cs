﻿using System;
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
            Button? button = sender as Button;
            UniformGrid? parrent1 = button?.Parent as UniformGrid;
            UniformGrid? parrent2 = parrent1?.Parent as UniformGrid;
            ListBoxItem? listBoxItem = parrent2?.Parent as ListBoxItem;

            listBoxItem.IsSelected = true;

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
    }
}
