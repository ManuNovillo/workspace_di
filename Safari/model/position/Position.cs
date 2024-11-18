namespace Safari.model.position
{
    /*public class Position
    {

        /// <summary>
        /// Coordenada x, siendo 0 el borde izquierdo de la pantalla y cada vez más grande
        /// al desplazarnos hacia la derecha
        /// </summary>
        public int fila { get; set; }

        /// <summary>
        /// Coordenada y, siendo 0 el borde superior de la pantalla y cada vez más grande
        /// al desplazarnos hacia abajo
        /// </summary>
        public int columna { get; set; }

        public Position(int fila, int columna) {
            this.fila = fila;
            this.columna = columna; 
        }
    }*/

    public record Position(int fila, int columna);
}
