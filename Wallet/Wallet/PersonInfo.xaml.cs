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
    /// Interaction logic for PersonInfo.xaml
    /// </summary>
    public partial class PersonInfo : Window
    {
        private bool name;
        private bool surename;
        private bool phoneNumber;

        public PersonInfo()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? save = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                save?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Владелец был сохранен.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            switch (textBox.Name)
            {
                case "Name":
                    if (Regular.CheckName(textBox.Text))
                        name = true;
                    else
                        name = false;
                    break;
                case "Surename":
                    if (Regular.CheckSurname(textBox.Text))
                        surename = true;
                    else
                        surename = false;
                    break;
                case "PhoneNumber":
                    if (Regular.CheckNumber(textBox.Text))
                        phoneNumber = true;
                    else
                        phoneNumber = false;
                    break;
            }

            if (name && surename && phoneNumber)
                Save.IsEnabled = true;
            else
                Save.IsEnabled = false;
        }
    }
}
