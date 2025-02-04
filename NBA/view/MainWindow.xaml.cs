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
        public MainWindow()
        {
            controller = new Controller();
            InitializeComponent();
            loadTeams();
            ViewTeam team = equiposListBox.Items[0] as ViewTeam;
            loadTeamLogo(team.Logo);
        }


        private void loadTeams()
        {
            List<ViewTeam> teams = controller.getAllTeams();
            equiposListBox.ItemsSource = teams;
        }
        private void loadTeamLogo(String logo)
        {
            BitmapImage logoBitMap = new BitmapImage();
            logoBitMap.BeginInit();
            logoBitMap.UriSource = new Uri(logo);
            logoBitMap.EndInit();
            equipoImage.Source = logoBitMap;
        }

        private void equiposListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (equiposListBox.SelectedItem != null)
            {
                ViewTeam team = equiposListBox.SelectedValue as ViewTeam;
                loadTeamLogo(team.Logo);
            }
        }
    }
}
