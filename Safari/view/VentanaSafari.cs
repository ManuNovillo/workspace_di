using Safari.controller;
using Safari.model.position;
using Safari.model.seres;

namespace Safari
{
    public partial class VentanaSafari : Form
    {
        private Thread hiloSafari;

        private bool autoplayActivado;
        private Controller controller { get; set; }
        public VentanaSafari(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            hiloSafari = new(() =>
            {
                while (true)
                {
                    if (autoplayActivado)
                    {
                        step();
                        Thread.Sleep(2000);
                    }
                }
            });
            hiloSafari.IsBackground = true;
            hiloSafari.Start();
        }

        private void paintSafari(Graphics g)
        {
            Dictionary<Position, Ser?> seres = controller.getSeres();

            Font font = new Font("Arial", 8);

            updateLabels();
            foreach (var entry in seres)
            {
                /*String texto = entry.Value != null ? entry.Value.ToString() : "";
                g.DrawString(texto, font, brush,entry.Key.X * 50, entry.Key.Y * 50 );*/
                Ser? ser = entry.Value;

                if (ser != null)
                {
                    var image = Image.FromFile($"..\\..\\..\\view\\img\\{ser}.png");
                    var bitmap = new Bitmap(40, 40);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, entry.Key.columna * 50, entry.Key.fila * 50, 40, 40);
                    //g.DrawString(ser.ToString() + ser.num, new Font("Arial", 10), new SolidBrush(Color.Black), entry.Key.columna * 80, entry.Key.fila * 80);
                }
            }
            Update();
        }

        private void updateLabels()
        {
            plantasLabel.Text = $"PLANTAS: {controller.getNumeroPlantas()}";
            leonesLabel.Text = $"LEONES: {controller.getNumeroLeones()}";
            gacelasLabel.Text = $"GACELAS: {controller.getNumeroGacelas()}";
            totalLabel.Text = $"TOTAL: {controller.getNumeroSeres()}";
            diasLabel.Text = $"PASOS: {controller.getNumeroPasos()}";
        }

        private void panelSfari_Paint(object sender, PaintEventArgs e)
        {
            paintSafari(e.Graphics);
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
            controller.restartSafari();
            Refresh();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            autoplayActivado = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {

        }

        private void autoplay()
        {
            autoplayActivado = true;
        }

        private void step()
        {
            controller.step();
            Refresh();
        }
    }
}
