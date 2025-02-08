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

        /// <summary>
        /// Devuelve todos los equipos de la BBDD
        /// </summary>
        /// <returns>Una lista de <c>ViewTeam</c> con todos los equipos de la BBDD</returns>
        public List<ViewTeam> getAllTeams()
        {
            var equiposModelo = modelo.getAllTeams();
            var equiposVista = toListViewTeam(equiposModelo);
            return equiposVista;
        }

        public bool updatePlayer(ViewPlayer viewPlayer)
        {
            ModelPlayer modelPlayer = toModelPlayer(viewPlayer);
            return modelo.updatePlayer(modelPlayer);
        }
        public bool insertPlayer(ViewPlayer viewPlayer)
        {
            ModelPlayer modelPlayer = toModelPlayer(viewPlayer);
            return modelo.insertPlayer(modelPlayer);
        }

        public int getNewId()
        {
            return modelo.getNewId();
        }

        /// <summary>
        /// Devuelve un objeto de tipo <c>ModelPlayer</c> con los datos de <c><paramref name="viewPlayer"/></c>, incluyendo el equipo entero
        /// </summary>
        /// <param name="viewPlayer">El jugador de la vista con los datos</param>
        /// <returns>Un objeto <c>ModelTeam</c> con los datos del jugador de la vista, con el equipo incluido</returns>
        private ModelPlayer toModelPlayer(ViewPlayer viewPlayer)
        {
            var modelPlayer = new ModelPlayer();
            modelPlayer.Id = viewPlayer.Id;
            modelPlayer.Nombre = viewPlayer.Nombre;
            modelPlayer.Apellidos = viewPlayer.Apellidos;
            modelPlayer.Posicion = viewPlayer.Posicion;
            modelPlayer.Imagen = viewPlayer.Imagen;
            modelPlayer.Equipo = toModelTeam(viewPlayer.Equipo);
            return modelPlayer;
        }

        /// <summary>
        /// Crea un objeto <c>ModelTeam</c> a partir de los datos de <c><paramref name="viewTeam"/></c>, pero sin los jugadores
        /// </summary>
        /// <param name="viewTeam">El equipo de la vista con los datos</param>
        /// <returns>Un objeto <c>ModelTeam</c> con los datos del equipo de la vista, sin los jugadores</returns>
        private ModelTeam toModelTeam(ViewTeam viewTeam)
        {
            var modelTeam = new ModelTeam();
            modelTeam.Id = viewTeam.Id;
            modelTeam.Nombre = viewTeam.Nombre;
            modelTeam.Logo = modelTeam.Logo;

            return modelTeam;
        }

        /// <summary>
        /// Devuelve un objeto de tipo <c>ViewPlayer</c> con los datos de <c><paramref name="modelPlayer"/></c>, incluyendo el equipo entero
        /// </summary>
        /// <param name="modelPlayer">El jugador del modelo con los datos</param>
        /// <returns>Un objeto <c>ViewPlayer</c> con los datos del jugador del modelo, con el equipo incluido</returns>
        private ViewPlayer toViewPlayer(ModelPlayer modelPlayer)
        {
            var viewPlayer = new ViewPlayer();
            viewPlayer.Id = modelPlayer.Id;
            viewPlayer.Nombre = modelPlayer.Nombre;
            viewPlayer.Apellidos = modelPlayer.Apellidos;
            viewPlayer.Posicion = modelPlayer.Posicion;
            viewPlayer.Imagen = modelPlayer.Imagen;

            return viewPlayer;
        }

        /// <summary>
        /// Devuelve una lista de <c>ViewPlayer</c> con los datos de <c><paramref name="modelPlayers" /></c>
        /// </summary>
        /// <param name="modelPlayers">La lista con los jugadores del modelo</param>
        /// <returns>Una lista de <c>ViewPlayer</c> con los datos de los jugadores del modelo</returns>
        private List<ViewPlayer> toListViewPlayer(List<ModelPlayer> modelPlayers)
        {
            var viewPlayers = new List<ViewPlayer>();
            modelPlayers.ForEach(modelPlayer => {
                var viewPlayer = toViewPlayer(modelPlayer);
                viewPlayers.Add(viewPlayer);
            });

            return viewPlayers;
        }

        /// <summary>
        /// Crea un objeto <c>ViewTeam</c> a partir de los datos de <c><paramref name="modelTeam"/></c>, pero sin los jugadores
        /// </summary>
        /// <param name="modelTeam">El equipo del modelo con los datos</param>
        /// <returns>Un objeto <c>ViewTeam</c> con los datos del equipo del modelo con los datos, sin los jugadores</returns>
        private ViewTeam toViewTeam(ModelTeam modelTeam)
        {
            var viewTeam = new ViewTeam();
            viewTeam.Id = modelTeam.Id;
            viewTeam.Nombre = modelTeam.Nombre;
            viewTeam.Logo = modelTeam.Logo;

            return viewTeam;
        }

        /// <summary>
        /// Devuelve una lista de <c>ViewTeam</c> con los datos de <c><paramref name="modelTeams"/></c>
        /// </summary>
        /// <param name="modelTeams">La lista con los equipos del modelo</param>
        /// <returns>Una lista de <c>ViewTeam</c> con los datos de los equipos del modelo</returns>
        private List<ViewTeam> toListViewTeam(List<ModelTeam> modelTeams)
        {
            var viewTeams = new List<ViewTeam>();
            modelTeams.ForEach(modelTeam =>
            {
                var viewTeam = toViewTeam(modelTeam);
                viewTeam.Jugadores = toListViewPlayer(modelTeam.Jugadores);
                viewTeam.Jugadores.ForEach(jugador => jugador.Equipo = viewTeam);
                viewTeams.Add(viewTeam);
            });

            return viewTeams;
        }

        public bool deletePlayer(ViewPlayer viewPlayer)
        {
            var modelPlayer = toModelPlayer(viewPlayer);
            return modelo.deletePlayer(modelPlayer);
        }

        public bool updateTeam(ViewTeam equipo, String nombreViejo)
        {
            var modelTeam = toModelTeam(equipo);
            return modelo.updateEquipo(modelTeam, nombreViejo);
        }
    }
}
