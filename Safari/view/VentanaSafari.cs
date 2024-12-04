using Safari.controller;
using Safari.model.position;
using Safari.model.seres;

namespace Safari
{
    public partial class VentanaSafari : Form
    {
        private Thread hiloSafari;

        CancellationTokenSource token;

        private bool autoplayActivado;
        private Controller controller { get; set; }
        public VentanaSafari(Controller controller)
        {
            this.controller = controller;
            token = new();
            InitializeComponent();
            hiloSafari = new(() => autoplay());

            hiloSafari.IsBackground = true;
            hiloSafari.Start();
        }
        /// <summary>
        /// Pinta todos los elementos del safari, es decir, los seres y las labels
        /// </summary>
        /// <param name="g"></param>
        private void paintSafari(Graphics g)
        {
            Dictionary<Posicion, Ser?> seres = controller.getSeres();

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
            pasosLabel.Text = $"PASOS: {controller.getNumeroPasos()}";
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
            autoplayActivado = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            controller.restartSafari();
            stopButton.Enabled = true;
            pauseButton.Enabled = true;
            autoplayButton.Enabled = true;
            stepButton.Enabled = true;
            Refresh();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            autoplayActivado = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            token.Cancel();
            token.Dispose();
            stopButton.Enabled = false;
            pauseButton.Enabled = false;
            autoplayButton.Enabled = false;
            stepButton.Enabled = false;
            resetButton.Enabled = false;
        }

        private void autoplay()
        {
            while (!token.IsCancellationRequested)
            {
                if (autoplayActivado)
                {
                    step();
                    Thread.Sleep(2000);
                }
            }
        }

        private void step()
        {
            controller.step();
            Refresh();
            if (controller.debeTerminarSimulacion())
            {
                stopButton.Enabled = false;
                pauseButton.Enabled = false;
                autoplayButton.Enabled = false;
                stepButton.Enabled = false;
            }
        }
    }
}
