﻿using System;
using System.Collections.Generic;

namespace NBA.view.entities
{

    /// <summary>
    /// Clase para encapsular en un objeto los datos que vienen desde el modelo sobre los equipos de la bdd
    /// </summary>
    public class ViewTeam
    {
        // Campos privados
        private int id;
        private String nombre;
        private String logo;

        /// <summary>
        /// Lista que contiene los jugadores del equipo
        /// </summary>
        private List<ViewPlayer> jugadores;

        // Propiedades públicas
        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Logo { get => logo; set => logo = value; }
        public List<ViewPlayer> Jugadores { get => jugadores; set => jugadores = value; }

        public override String ToString()
        {
            return nombre;
        }
    }
}
