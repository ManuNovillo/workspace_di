using NBA.view.entities;
using NBAmodel;
using System.Collections.Generic;
using System;
using NBA.model.entities;

namespace NBA.controller
{
    public class Controller
    {
        private Modelo modelo;

        public Controller() {
            modelo = new Modelo(); 
        }
        public List<ViewTeam> getAllTeams()
        {
            var equiposModelo = modelo.getAllTeams();
            var equiposVista = toListViewTeam(equiposModelo);
            return equiposVista;
        }

        private List<ViewTeam> toListViewTeam(List<ModelTeam> equiposModelo)
        {
            var equiposVista = new List<ViewTeam>();
            equiposModelo.ForEach(equipoModelo =>
            {
                var equipoVista = new ViewTeam();
                equipoVista.Id = equipoModelo.Id;
                equipoVista.Nombre = equipoModelo.Nombre;
                equipoVista.Logo = equipoModelo.Logo;
                List<ViewPlayer> jugadoresVista = new List<ViewPlayer>();
                equipoModelo.Jugadores.ForEach(jugadorModelo =>
                {
                    var jugadorVista = new ViewPlayer();
                    jugadorVista.Id = jugadorModelo.Id;
                    jugadorVista.Nombre = jugadorModelo.Nombre;
                    jugadorVista.Apellidos = jugadorModelo.Apellidos;
                    jugadorVista.Posicion = jugadorModelo.Posicion;
                    jugadorVista.Equipo = equipoVista;
                    jugadoresVista.Add(jugadorVista);
                });
                equipoVista.Jugadores = jugadoresVista;
                equiposVista.Add(equipoVista);
            });
            return equiposVista;
        }

        private ModelPlayer toModelPlayer(ViewPlayer viewPlayer)
        {
            ModelPlayer modelPlayer = new ModelPlayer();
            modelPlayer.Id = viewPlayer.Id;
            modelPlayer.Nombre = viewPlayer.Nombre;
            modelPlayer.Apellidos = viewPlayer.Apellidos;
            modelPlayer.Imagen = viewPlayer.Imagen;
            modelPlayer.Posicion = viewPlayer.Posicion;
            ModelTeam modelTeam = new ModelTeam();
            ViewTeam viewTeam = viewPlayer.Equipo;
            modelTeam.Id = viewTeam.Id;
            modelTeam.Nombre = viewTeam.Nombre;
            modelTeam.Logo = viewTeam.Logo;
            modelPlayer.Equipo = modelTeam;

            return modelPlayer;
        }
    }
}
