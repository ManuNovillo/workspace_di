using NBA.view.entities;
using NBAmodel;
using System.Collections.Generic;
using System;

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
            var equiposVista = new List<ViewTeam>();
            equiposModelo.ForEach(equipoModelo =>
            {
                var equipoVista = new ViewTeam();
                equipoVista.Id = equipoModelo.Id;
                equipoVista.Nombre = equipoModelo.Nombre;
                equipoVista.Imagen = equipoModelo.Imagen;
                List<ViewPlayer> jugadoresVista = new List<ViewPlayer>();
                equipoModelo.Jugadores.ForEach(jugadorModelo =>
            {
                    var jugadorVista = new ViewPlayer();
                    jugadorVista.Id = jugadorModelo.Id;
                    String info = $"{jugadorModelo.Posicion} -> {jugadorModelo.Apellidos}, {jugadorModelo.Nombre}";
                    jugadorVista.Info = info;
                    jugadorVista.Equipo = equipoVista;
                    jugadoresVista.Add(jugadorVista);
                });
                equipoVista.Jugadores = jugadoresVista;
                equiposVista.Add(equipoVista);
            });
            return equiposVista;
        }
    }
}
