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
        public event EventHandler<EventArgs>? day = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Month_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Day_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
