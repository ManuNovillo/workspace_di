using Safari.controller;
using Safari.model.position;
using Safari.model.seres;

namespace Safari
{
    public partial class Form1 : Form
    {
        Thread hiloSafari;
        private Controller controller { get; set; }
        public Form1(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void paintSeres(Graphics g)
        {
            Dictionary<Position, Ser?> seres = controller.getSeres();

            Font font = new Font("Arial", 8);
            var contador = 0;
            foreach (var entry in seres)
            {
                //String texto = entry.Value != null ? entry.Value.ToString() : "";
                //g.DrawString(texto, font, brush,entry.Key.X * 50, entry.Key.Y * 50 );
                Ser? ser = entry.Value;

                if (ser != null)
                {
                    /*var image = Image.FromFile($"..\\..\\..\\view\\img\\{ser.ToString()}.png");
                    var bitmap = new Bitmap(40, 40);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, entry.Key.columna * 50, entry.Key.fila * 50, 40, 40);*/
                    g.DrawString(ser.ToString() + ser.num, new Font("Arial", 10), new SolidBrush(Color.Black), entry.Key.columna * 80, entry.Key.fila * 80);
                    contador++;
                }
            }
            Update();
        }

        private void panelSfari_Paint(object sender, PaintEventArgs e)
        {
            paintSeres(e.Graphics);
        }


        private void stepButton_Click(object sender, EventArgs e)
        {
            step();
        }
        private void autoPlayButton_Click(object sender, EventArgs e)
        {
            autoplay();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {

        }

        private void pauseButton_Click(object sender, EventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {

        }

        private void autoplay()
        {
            Thread thread = new(() =>
            {
                while (true)
                {
                    step();
                    Thread.Sleep(2000);
                }

            });
            thread.IsBackground = true;
            thread.Start();

        }

        private void step()
        {
            controller.step();
            Refresh();
        }

    }
}
