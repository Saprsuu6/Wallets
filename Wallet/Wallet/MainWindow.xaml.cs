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
                MessageBox.Show("Карта была добавлена.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
