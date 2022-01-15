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

namespace Wallet
{
    /// <summary>
    /// Interaction logic for Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {
        public Statistic()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? year = null;
        public event EventHandler<EventArgs>? month = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChange(sender as TextBox);

            try
            {
                year?.Invoke(this, new EventArgs());
            }
            catch (Exception)
            {
                Chart.Visibility = Visibility.Hidden;
                NotExists.Visibility = Visibility.Visible;
            }
        }

        private void Month_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChange(sender as TextBox);

            try
            {
                month?.Invoke(this, new EventArgs());
            }
            catch (Exception)
            {
                Chart.Visibility = Visibility.Hidden;
                NotExists.Visibility = Visibility.Visible;
            }
        }

        private void TextChange(TextBox? box)
        {
            box.Text = box.Text.Trim();

            if (box.Text.Length == 0)
            {
                switch (box.Name)
                {
                    case "Year":
                        box.Text = DateTime.Now.Year.ToString();
                        break;

                    case "Month":
                        box.Text = DateTime.Now.Month.ToString();
                        break;
                }
            }
        }
    }
}
