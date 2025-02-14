using NBA.controller;
using NBA.view.entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NBA.view
{
    /// <summary>
    /// Lógica de interacción para BuscarJugadorWindow.xaml
    /// </summary>
    public partial class BuscarJugadorWindow : Window
    {
        private Controller controller;
        private DataGrid dataGrid;

        /// <summary>
        /// Crea una BuscarJugadorWindow preparada para mostrar los jugadores encontrados en <c><paramref name="dataGrid"/></c>
        /// </summary>
        /// <param name="dataGrid">El DataGrid donde mostrar los jugadores encontrados</param>
        public BuscarJugadorWindow(Controller controller, DataGrid dataGrid)
        {
            InitializeComponent();
            this.controller = controller;
            this.dataGrid = dataGrid;
        }

        private void buscar_Click(object sender, RoutedEventArgs e)
        {
            var apellidoIntroducido = apellidoTextBox.Text;
            var jugadores = controller.getAllPlayers();
            // Loopear jugadores y filtrar por el apellido introducido, sin mirar mayúsculas ni minúsculas
            List<ViewPlayer> jugadoresFiltrados = jugadores.FindAll(jugador => 
                string.Equals(jugador.Apellidos, apellidoIntroducido, StringComparison.OrdinalIgnoreCase)
            );
            if (jugadoresFiltrados.Count == 0) // Si no se han encontrado jugadores
                MessageBox.Show("No hay jugadores con este apellido");
            else
            {
                dataGrid.ItemsSource = jugadoresFiltrados;
                Close();
            }
        }
    }
}
