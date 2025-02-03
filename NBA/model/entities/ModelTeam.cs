using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.model.entities
{
    /// <summary>
    /// Clase que representa los equipos del modelo de datos
    /// </summary>
    public class ModelTeam
    {
        private int id;
        private String nombre;
        private String imagen;
        private List<ModelPlayer> jugadores;

        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Imagen { get => imagen; set => imagen = value; }
        public List<ModelPlayer> Jugadores { get => jugadores; set => jugadores = value; }

    }
}
