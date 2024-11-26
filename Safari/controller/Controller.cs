using Safari.model;
using Safari.model.position;
using Safari.model.seres;

namespace Safari.controller
{
    public class Controller
    {
        private MiSafari safari;

        public Controller(MiSafari safari) 
        { 
            this.safari = safari;
        }

        public void startSafari(int filas, int columnas)
        {
            safari.setDimensiones(filas, columnas);
            safari.fillParcela();
            VentanaSafari form = new VentanaSafari(this);
            form.ShowDialog();
        }

        public int getFilasMaximas()
        {
            return safari.getFilasMaximas();
        }

        public int getColumnasMaximas()
        {
            return safari.getColumnasMaximas();
        }

        public int getFilasMinimas()
        {
            return safari.getFilasMinimas();
        }

        public int getColumnasMinimas()
        {
            return safari.getColumnasMinimas();
        }

        public void step()
        {
            safari.step();
        }

        public Dictionary<Position, Ser?> getSeres()
        {
            return safari.getSeres();
        }
    }
}
