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
    /// Interaction logic for Consumptions.xaml
    /// </summary>
    public partial class Consumptions : Window
    {
        public Consumptions()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? ascending = null;
        public event EventHandler<EventArgs>? descending = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Ascending.IsChecked == true)
                ascending?.Invoke(this, new EventArgs());
            else if (Descending.IsChecked == true)
                descending?.Invoke(this, new EventArgs());
        }
    }
}
