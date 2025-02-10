using NBA.controller;
using NBA.view.entities;
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

namespace NBA.view
{
    /// <summary>
    /// Lógica de interacción para ActualizaEquipoWindow.xaml
    /// </summary>
    public partial class ActualizaEquipoWindow : Window
    {
        private Controller controller;
        private ViewTeam equipo;
        public ActualizaEquipoWindow(Controller controller, ViewTeam equipo)
        {
            this.controller = controller;
            this.equipo = equipo;
            InitializeComponent();
            nombreTextBox.Text = equipo.Nombre;
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if (nombreTextBox.Text != "")
            {
                // Guardar y pasar el nombre viejo del equipo al ccontroller
                // para poder cambiar los equipos de los jugadores
                var nombreViejo = equipo.Nombre;
                equipo.Nombre = nombreTextBox.Text;
                bool haIdoBien = controller.updateTeam(equipo, nombreViejo);
                if (haIdoBien)
                    MessageBox.Show("Operación realizada correctamente");
                else
                    MessageBox.Show("Error al realizar la operación");

                Close();
            }
            else
            {
                MessageBox.Show("Introduce un nombre");
            }
        }

        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
