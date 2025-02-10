using System;

namespace NBA.view.entities
{
    /// <summary>
    /// Clase para encapsular en un objeto los datos que vienen desde el modelo sobre los jugadores de la bdd
    /// </summary>
    public class ViewPlayer
    {
        // Campos privados
        private int id;
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
        
        public override string ToString()
        {
            return $"{posicion} -> {apellidos}, {nombre}";
        }

    }
}
