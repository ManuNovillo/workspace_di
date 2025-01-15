using System;
using System.Windows;

namespace WpfConBBDD
{
    /// <summary>
    /// Lógica de interacción para InsertClienteWindow.xaml
    /// </summary>
    public partial class InsertClienteWindow : Window
    {
        public InsertClienteWindow()
        {
            InitializeComponent();
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
