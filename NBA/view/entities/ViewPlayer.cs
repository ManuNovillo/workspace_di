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
        private String info;
        private ViewTeam equipo;

        // Propiedades públicas
        public int Id { get => id; set => id = value; }
        public String Info { get => info; set => info = value; }
        public ViewTeam Equipo { get => equipo; set => equipo = value; }
        
        public string ToString()
        {
            return info;
        }

    }
}
