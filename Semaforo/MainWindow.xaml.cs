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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semaforo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constuyre una ventana e ina
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Si el boton rojo 
        /// </summary>
        /// <param name="sender">El objeto que origina el evento</param>
        /// <param name="e"> El evento originado por </param>
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (RBred.IsFocused) //Si el boton rojo tiene el foco, lo ahcemos visible y el resto los escondemos
            {
                eRojo.Visibility = Visibility.Visible;
                eAmbar.Visibility = Visibility.Hidden;
                eVerde.Visibility = Visibility.Hidden;
            }
            else if (RBOrange.IsFocused) //Si el boton rojo tiene el foco, lo ahcemos visible y el resto los escondemos
            {
                eRojo.Visibility = Visibility.Hidden;
                eAmbar.Visibility = Visibility.Visible;
                eVerde.Visibility = Visibility.Hidden;
            }
            else if (RBVerde.IsFocused)
            {
                eRojo.Visibility = Visibility.Hidden;
                eAmbar.Visibility = Visibility.Hidden;
                eVerde.Visibility = Visibility.Visible;
            }
        }
    }
}
