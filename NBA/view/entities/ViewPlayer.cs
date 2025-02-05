using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.view.entities
{
    public class ViewPlayer
    {
        // Campos privados
        private int id;
        /// <summary>
        /// Campo que tiene como texto "posicion -> apellidos, nombre"
        /// </summary>
        private String nombre;
        private String apellidos;
        private String posicion;
        private String imagen;
        private ViewTeam equipo;

        // Propiedades públicas
        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Posicion { get => posicion; set => posicion = value; }
        public String Apellidos { get => apellidos; set => apellidos = value; }
        public String Imagen { get => imagen; set => imagen = value; }
        public ViewTeam Equipo { get => equipo; set => equipo = value; }
        
        public string ToString()
        {
            return $"{posicion} -> {apellidos}, {nombre}";
        }

    }
}
