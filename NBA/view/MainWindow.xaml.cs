﻿using NBA.controller;
using NBA.view;
using NBA.view.entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NBA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;

        private List<ViewTeam> equipos;
        private ViewTeam equipoSeleccionado;
        private ViewPlayer jugadorSeleccionado;

        public MainWindow()
        {
            controller = new Controller();
            InitializeComponent();
            equipos = controller.getAllTeams();
            equiposListBox.ItemsSource = equipos;
            // Establecer como equipo por defecto el primer equipo
            equipoSeleccionado = equipos[0];
            loadTeamLogos();
            jugadoresListBox.ItemsSource = equipoSeleccionado.Jugadores;
            // Establecer como jugador por defecto el primer jugador del equipo por defecto
            jugadorSeleccionado = equipoSeleccionado.Jugadores[0];
            loadJugadorSeleccionado();

        }

        /// <summary>
        /// Carga todos los datos en las dos últimas pestañas del jugador seleccionado
        /// </summary>
        private void loadJugadorSeleccionado()
        {
            loadJugadorImages();
            // Crear lista para meter el jugador para poder pasárselo al DataGrid, ya que no se puede pasar simplemente
            // un objeto ViewPlayer
            var data = new List<ViewPlayer>();
            data.Add(jugadorSeleccionado);
            jugadorDataGrid.ItemsSource = data;
            jugadorDataGrid.IsReadOnly = true;
        }


        private void equiposListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (equiposListBox.SelectedItem != null)
            {
                ViewTeam team = equiposListBox.SelectedValue as ViewTeam;
                equipoSeleccionado = team;
                jugadoresListBox.ItemsSource = equipoSeleccionado.Jugadores;
                loadTeamLogos();
                // Establecer el primer jugador del equipo seleccionado como el jugador seleccionado por defecto
                jugadorSeleccionado = equipoSeleccionado.Jugadores[0];
                loadJugadorSeleccionado();
            }
        }

        private void jugadoresListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (jugadoresListBox.SelectedItem != null)
            {
                ViewPlayer player = jugadoresListBox.SelectedValue as ViewPlayer;
                jugadorSeleccionado = player;
                loadJugadorSeleccionado();
            }
        }

        /// <summary>
        /// Carga la imagen de la pestaña Equipo con el logo del equipo seleccionado
        /// </summary>
        private void loadTeamLogos()
        {
            loadImage(equipoImage, equipoSeleccionado.Logo);
            loadImage(tabPlantillaImage, equipoSeleccionado.Logo);
        }
        
        /// <summary>
        /// Carga las imagenes de la pestaña Plantilla y de la pestaña Jugador con la foto del jugador seleccionado
        /// </summary>
        private void loadJugadorImages()
        {
            loadImage(jugadorPlantillaImage, jugadorSeleccionado.Imagen);
            loadImage(jugadorImage, jugadorSeleccionado.Imagen);
        }

        /// <summary>
        /// Carga la imagen <c><paramref name="image"/></c> con la URI <c><paramref name="uri"/></c> especificada:
        /// Si la URI especificada no es correcta o es <c>null</c>, se cargará la foto por defecto de foto no
        /// encontrada
        /// </summary>
        /// <param name="image">La imagen a cargar</param>
        /// <param name="uri">La URI con la foto a mostrar</param>
        private void loadImage(Image image, String uri)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();

            // Si existe la foto a mostrar, mostrarla
            if (uri != null && uri != "" && uri != "null")
                bitmap.UriSource = new Uri(uri);

            // Si no, poner la imagen
            else
                bitmap.UriSource = new Uri("../view/img/no-image.jpg", UriKind.Relative);

            bitmap.EndInit();
            image.Source = bitmap;
        }

        /// <summary>
        /// Manejador del evento de cuando se genera una columna del DataGrid del jugador (<c>jugadorDataGrid</c>)
        /// Este método evita que se genere la columna Imagen
        /// </summary>
        private void jugadorDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Imagen")
                e.Column = null;
        }

        private void updateTeam_Click(object sender, RoutedEventArgs e)
        {
            openUpdateTeamWindow();
        }

        private void openUpdateTeamWindow()
        {
            ActualizaEquipoWindow actualizaEquipoWindow = new ActualizaEquipoWindow(controller, equipoSeleccionado);
            actualizaEquipoWindow.ShowDialog();
            equiposListBox.Items.Refresh();
            jugadorDataGrid.Items.Refresh();
        }

        private void insertPLayer_Click(object sender, RoutedEventArgs e)
        {
            openPlayerWindow(JugadorAction.INSERT);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var ctrlPulsado = (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
            if (ctrlPulsado) 
            {
                if (pulsadoUpdateEquipo(e.Key))
                    openUpdateTeamWindow();

                else if (pulsadoInsertarJugador(e.Key))
                    openPlayerWindow(JugadorAction.INSERT);

                else if (pulsadoUpdateJugador(e.Key))
                    openPlayerWindow(JugadorAction.UPDATE);

                else if (pulsadoDeleteJugador(e.Key))
                    deleteSelectedPlayer();

                else if (pulsadoAyuda(e.Key))
                    mostrarAyuda();

                else if (pulsadoAcercaDe(e.Key))
                    mostrarAcercaDe();

                // EXAMEN 3
                else if (pulsadoBuscarJugador(e.Key))
                    showBuscarJugadorWindow();

                // EXAMEN 1
                else if (pulsadoImprimirEquipos(e.Key))
                    showImprimirWindow();

                else if (pulsadoSalir(e.Key))
                    Close();
            }
        }

        // EXAMEN 1
        private bool pulsadoImprimirEquipos(Key key)
        {
            return key == Key.P;
        }

        // EXAMEN 3
        private bool pulsadoBuscarJugador(Key key)
        {
            return key == Key.B;
        }

        private bool pulsadoUpdateEquipo(Key key)
        {
            return key == Key.E;
        }

        private bool pulsadoInsertarJugador(Key key)
        {
            return key == Key.I;
        }

        private bool pulsadoUpdateJugador(Key key)
        {
            return key == Key.J;
        }

        private bool pulsadoDeleteJugador(Key key)
        {
            return key == Key.D;
        }

        private bool pulsadoAyuda(Key key)
        {
            return key == Key.H;
        }

        private bool pulsadoAcercaDe(Key key)
        {
            return key == Key.T;
        }

        private bool pulsadoSalir(Key key)
        {
            return key == Key.Q;
        }
        private void openPlayerWindow(JugadorAction action)
        {
            bool esInsert = action == JugadorAction.INSERT;
            PlayerWindow playerWindow;
            if (esInsert)
            {
                playerWindow = new PlayerWindow(controller, "Insertar nuevo jugador", equipos);
            }
            else
            {
                if (jugadorSeleccionado is null)
                {
                    MessageBox.Show("Elige un jugador");
                    return;
                }
                playerWindow = new PlayerWindow(controller, "Actualizar jugador", jugadorSeleccionado, equipos);
            }
            playerWindow.ShowDialog();

            // Refrescar jugadores para mostrar los cambios
            jugadoresListBox.Items.Refresh();
            jugadorDataGrid.Items.Refresh();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            mostrarAyuda();
        }

        private void acercaDe_Click(object sender, RoutedEventArgs e)
        {
            mostrarAcercaDe();
        }

        private void mostrarAcercaDe()
        {
            AcercaDeWindow acercaDeWindow = new AcercaDeWindow();
            acercaDeWindow.ShowDialog();
        }

        private void actualizarButton_Click(object sender, RoutedEventArgs e)
        {
            openPlayerWindow(JugadorAction.UPDATE);
        }

        private void borrarButton_Click(object sender, RoutedEventArgs e)
        {
            deleteSelectedPlayer();
        }

        private void deleteSelectedPlayer()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("¿Seguro que quieres borrar este jugador?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                bool haIdoBien = controller.deletePlayer(jugadorSeleccionado);

                if (haIdoBien)
                {
                    MessageBox.Show("Operación realizada con éxito");
                    equipoSeleccionado.Jugadores.Remove(jugadorSeleccionado);
                    jugadoresListBox.Items.Refresh();
                    jugadorSeleccionado = equipoSeleccionado.Jugadores[0];
                    loadJugadorSeleccionado();
                }
                else
                    MessageBox.Show("Error al realizar la operación");

            }
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void mostrarAyuda()
        {
            AyudaWindow ayudaWindow = new AyudaWindow();
            ayudaWindow.ShowDialog();
        }
        /// <summary>
        /// Enum que representa las acciones que se pueden hacer con la ventana de jugadores
        /// </summary>
        private enum JugadorAction
        {
            INSERT, UPDATE
        }

        private void imprimirEquipoButton_Click(object sender, RoutedEventArgs e)
        {
            showImprimirWindow();
        }

        private void imprimirPlantillaButton_Click(object sender, RoutedEventArgs e)
        {
            showImprimirWindow(plantillaGrid);
        }
        private void imprimirJugadorButton_Click(object sender, RoutedEventArgs e)
        {
            showImprimirWindow(playerGrid);
        }

        private void showImprimirWindow(Grid grid)
        {
            var imprimirWindow = new ImprimirWindow(grid);
            imprimirWindow.ShowDialog();
        }
        // EXAMEN 1
        private void showImprimirWindow()
        {
            var imprimirWindow = new ImprimirWindow(equipos);
            imprimirWindow.ShowDialog();
        }

        // EXAMEN 3
        /// <summary>
        /// Manejador de eventos de cuando se pulsa el botón de buscar jugador de la barra de herramientas o del menú
        /// </summary>
        private void buscarJugador_Click(object sender, RoutedEventArgs e)
        {
            showBuscarJugadorWindow();
        }

        // EXAMEN 3
        private void showBuscarJugadorWindow()
        {
            BuscarJugadorWindow buscarJugadorWindow = new BuscarJugadorWindow(controller, jugadorDataGrid);
            buscarJugadorWindow.ShowDialog();
            jugadorTab.IsSelected = true;
        }
    }
}
