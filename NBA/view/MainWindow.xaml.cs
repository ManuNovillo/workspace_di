using NBA.controller;
using NBA.view.entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NBA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;

        private ViewTeam equipoSeleccionado;
        private ViewPlayer jugadorSeleccionado;

        private TabItem tabSeleccionada;
        public MainWindow()
        {
            controller = new Controller();
            InitializeComponent();
            List<ViewTeam> teams = controller.getAllTeams();
            equiposListBox.ItemsSource = teams;
            // Establecer el primer equipo de la lista como el seleccionado por defecto
            equipoSeleccionado = equiposListBox.Items[0] as ViewTeam;
            loadTeamLogos();
            // Establecer el primer jugador del equipo seleccionado como el jugador seleccionado por defecto
            jugadorSeleccionado = equipoSeleccionado.Jugadores[0];
            loadJugadorSeleccionado();
        }


        private void loadJugadorSeleccionado()
        {
            loadJugadorImages();
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
            BitmapImage logoBitMap = new BitmapImage();
            logoBitMap.BeginInit();

            // Si existe la foto a mostrar, mostrarla
            if (uri != null && uri != "" && uri != "null")
                logoBitMap.UriSource = new Uri(uri);

            // Si no, poner la imagen
            else
                logoBitMap.UriSource = new Uri("../view/img/no-image.jpg", UriKind.Relative);

            logoBitMap.EndInit();
            image.Source = logoBitMap;
        }
    }
}
