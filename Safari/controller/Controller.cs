using Safari.model;

namespace Safari.controller
{
    public class Controller
    {
        internal MiSafari Safari { get;  set; }
        public Controller(MiSafari safari) 
        { 
            this.Safari = safari;
        }
        public void startSafari(int filas, int columnas)
        {
            Safari.setDimensiones(filas, columnas);
            Safari.fillParcela();
            Form1 form = new Form1(this);
            form.ShowDialog();
        }
    }
}
