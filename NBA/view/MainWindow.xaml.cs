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
        private ViewTeam equipoSeleccionado;
        private Controller controller;
        public MainWindow()
        {
            controller = new Controller();
            InitializeComponent();
            loadTeams();
            equipoSeleccionado = equiposListBox.Items[0] as ViewTeam;
            loadTeamLogo();
        }


        private void loadTeams()
        {
            List<ViewTeam> teams = controller.getAllTeams();
            equiposListBox.ItemsSource = teams;
        }
        private void loadTeamLogo()
        {
            BitmapImage logoBitMap = new BitmapImage();
            logoBitMap.BeginInit();
            logoBitMap.UriSource = new Uri(equipoSeleccionado.Logo);
            logoBitMap.EndInit();
            equipoImage.Source = logoBitMap;
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
    }
}
