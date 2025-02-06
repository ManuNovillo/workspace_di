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
        public MainWindow()
        {
            controller = new Controller();
            InitializeComponent();
            loadTeams();
            equipoSeleccionado = equiposListBox.Items[0] as ViewTeam;
            jugadorSeleccionado = equipoSeleccionado.Jugadores[0];
            loadTeamLogo();
            loadJugadorImage();
        }

        private void loadTeams()
        {
            List<ViewTeam> teams = controller.getAllTeams();
            equiposListBox.ItemsSource = teams;
        }

        private void equiposListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (equiposListBox.SelectedItem != null)
            {
                ViewTeam team = equiposListBox.SelectedValue as ViewTeam;
                equipoSeleccionado = team;
                loadTeamLogo();
            }
        }

        private void jugadoresListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (equiposListBox.SelectedItem != null)
            {
                ViewPlayer player = jugadoresListBox.SelectedValue as ViewPlayer;
                jugadorSeleccionado = player;
                loadJugadorImage();
            }
        }

        private void loadTeamLogo()
        {
            BitmapImage logoBitMap = new BitmapImage();
            logoBitMap.BeginInit();
            logoBitMap.UriSource = new Uri(equipoSeleccionado.Logo);
            logoBitMap.EndInit();
            equipoImage.Source = logoBitMap;
        }
        
        private void loadJugadorImage()
        {
            BitmapImage logoBitMap = new BitmapImage();
            String imagen = jugadorSeleccionado.Imagen is null ? "../../view/img/no-image.png" : jugadorSeleccionado.Imagen;
            logoBitMap.BeginInit();
            logoBitMap.UriSource = new Uri(imagen);
            logoBitMap.EndInit();
            jugadorImage.Source = logoBitMap;
        }
    }
}
