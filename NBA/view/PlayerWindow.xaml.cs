using NBA.controller;
using NBA.view.entities;
using System;
using System.Collections.Generic;
using System.Windows;

namespace NBA.view
{
    /// <summary>
    /// Ventana usada para insertar y actualizar jugadores
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private Controller controller;

        private ViewPlayer player;
        public PlayerWindow(Controller controller, String titulo, ViewPlayer player, List<ViewTeam> teams)
        {
            this.controller = controller;
            this.player = player;
            InitializeComponent();
            this.Title = titulo;
            cargarDatosJugador();
            teams.ForEach(team => equipoComboBox.Items.Add(team));
            equipoComboBox.SelectedItem = player.Equipo;
        }
        public PlayerWindow(Controller controller, String titulo, List<ViewTeam> teams)
        {
            this.controller = controller;
            InitializeComponent();
            this.Title = titulo;
            teams.ForEach(team => equipoComboBox.Items.Add(team));
        }
        private void cargarDatosJugador()
        {
            nombreTextBox.Text = player.Nombre;
            apellidosTextBox.Text = player.Apellidos;
            posicionTextBox.Text = player.Posicion;
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if (todosLosCamposCorrectos())
            {
                var hayQueInsertar = player is null;
                if (hayQueInsertar)
                {
                    player = new ViewPlayer();
                    player.Id = controller.getNewId();
                }
                player.Nombre = nombreTextBox.Text;
                player.Apellidos = apellidosTextBox.Text;
                player.Posicion = posicionTextBox.Text;
                var equipoAnterior = player.Equipo;
                player.Equipo = equipoComboBox.SelectedItem as ViewTeam; 
                // Añadir el jugador a la lista de jugadores de su equipo para
                // que se actualice en la vista
                if (hayQueInsertar) 
                    player.Equipo.Jugadores.Add(player);

                if (equipoAnterior != null && equipoAnterior.Nombre != player.Equipo.Nombre)
                {
                    // Si ha cambiado de equipo, borrarlo y añadirlo al otro
                    equipoAnterior.Jugadores.Remove(player);
                    player.Equipo.Jugadores.Add(player);
                }

                bool haIdoBien;
                if (hayQueInsertar)
                    haIdoBien = controller.insertPlayer(player);
                else 
                    haIdoBien = controller.updatePlayer(player);

                if (haIdoBien)
                    MessageBox.Show("Operación realizada con éxito");
                else
                    MessageBox.Show("Error al realizar la operación");

                Close();
            }
            else
            {
                MessageBox.Show("Comprueba los campos");
            }

        }

        private bool todosLosCamposCorrectos()
        {
            return
                equipoComboBox.SelectedItem != null
                && nombreTextBox.Text != ""
                && apellidosTextBox.Text != ""
                && posicionTextBox.Text != "";
        }
        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
