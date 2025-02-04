using System;
using System.Collections.Generic;

namespace NBA.view.entities
{
    public class ViewTeam
    {
        // Campos privados
        private int id;
        private String nombre;
        private String imagen;

        /// <summary>
        /// Lista que contiene los jugadores del equipo
        /// </summary>
        private List<ViewPlayer> jugadores;

        // Propiedades públicas
        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Imagen { get => imagen; set => imagen = value; }
        public List<ViewPlayer> Jugadores { get => jugadores; set => jugadores = value; }

        public override String ToString()
        {
            return nombre;
        }
    }
}
