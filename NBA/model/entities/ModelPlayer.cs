using System;

namespace NBA.model.entities
{
    public class ModelPlayer
    {
        // Campos privados
        private int id;
        private String nombre;
        private String apellidos;
        private String imagen;
        private String posicion;
        private ModelTeam equipo;

        // Propiedades públicas
        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellidos { get => apellidos; set => apellidos = value; }
        public String Imagen { get => imagen; set => imagen = value; }
        public String Posicion { get => posicion; set => posicion = value; }
        public ModelTeam Equipo{ get => equipo; set => equipo = value; }
        

    }
}
