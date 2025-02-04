using System;
using System.Collections.Generic;

namespace NBA.model.entities
{
    /// <summary>
    /// Clase que representa los equipos del modelo de datos
    /// </summary>
    public class ModelTeam
    {
        // Campos privados
        private int id;
        private String nombre;
        private String logo;

        /// <summary>
        /// Lista que contiene los jugadores del equipo
        /// </summary>
        private List<ModelPlayer> jugadores;

        // Propiedades públicas
        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Logo { get => logo; set => logo = value; }
        public List<ModelPlayer> Jugadores { get => jugadores; set => jugadores = value; }
    }
}
