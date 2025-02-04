using NBA.controller;
using NBA.view.entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NBA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            controller = new Controller();
            InitializeComponent();
            loadTeams();
            loadImage(equiposListBox.Items[0] as ViewTeam);
        }


        private void loadTeams()
        {
            List<ViewTeam> teams = controller.getAllTeams();
            equiposListBox.ItemsSource = teams;
        }
        private void loadImage(ViewTeam team)
        {
            BitmapImage imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.UriSource = new Uri(team.Imagen);
            imagen.EndInit();
            equipoImage.Source = imagen;
        }

        private void equiposListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (equiposListBox.SelectedItem != null)
            {
                loadImage(equiposListBox.SelectedItem as ViewTeam);
            }
        }
    }
}
