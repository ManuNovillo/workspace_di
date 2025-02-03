using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.model.entities
{
    public class ModelPlayer
    {
        private int id;
        private String nombre;
        private String apellidos;
        private String imagen;
        private ModelTeam equipo;

        public int Id { get => id; set => id = value; }
        public String Nombre{ get => nombre; set => nombre = value; }
        public String Apellidos{ get => apellidos; set => apellidos = value; }
        public String Imagen{ get => imagen; set => imagen = value; }
        public ModelTeam Equipo{ get => equipo; set => equipo = value; }
        

    }
}
