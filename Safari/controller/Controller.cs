using Safari.model;

namespace Safari.controller
{
    public class Controller
    {
        public MiSafari safari;

        public Controller(MiSafari safari) 
        { 
            this.safari = safari;
        }

        public void startSafari(int filas, int columnas)
        {
            safari.setDimensiones(filas, columnas);
            safari.fillParcela();
            Form1 form = new Form1(this);
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
    }
}
