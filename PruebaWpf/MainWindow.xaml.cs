using System.Windows;

namespace PruebaWpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PULSADO BOTON");
        }

        private void Panel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PULSADO PANEL");
        }

        private void MarcarTodas_Checked(object sender, RoutedEventArgs e)
        {
            Op1.IsChecked = true;
            Op2.IsChecked = true;
            Op3.IsChecked = true;
            Op4.IsChecked = true;
        }

        private void MarcarTodas_Unchecked(object sender, RoutedEventArgs e)
        {
            Op1.IsChecked = false;
            Op2.IsChecked = false;
            Op3.IsChecked = false;
            Op4.IsChecked = false;
        }

        private void Op_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Op1.IsChecked == false && Op2.IsChecked == false && Op3.IsChecked == false && Op4.IsChecked == false)
            {
                MarcarTodas.IsChecked = false;
            }
            else
            {
                MarcarTodas.IsChecked = null;
            }
        }

        private void Op_Checked(object sender, RoutedEventArgs e)
        {
            if (Op1.IsChecked == true && Op2.IsChecked == true && Op3.IsChecked == true && Op4.IsChecked == true)
            {
                MarcarTodas.IsChecked = true;
            }
            else
            {
                MarcarTodas.IsChecked = null;
            }
        }

    }
}
