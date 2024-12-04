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
            pauseButton.Enabled = false;
            hiloSafari.IsBackground = true;
        }
        /// <summary>
        /// Pinta todos los elementos del safari, es decir, los seres y las labels
        /// </summary>
        /// <param name="g"></param>
        private void paintSafari(Graphics g)
        {
            Dictionary<Posicion, Ser?> seres = controller.getSeres();
            updateLabels();
            foreach (var entry in seres)
            {
                Ser? ser = entry.Value;

                if (ser != null)
                {
                    var image = Image.FromFile($"..\\..\\..\\view\\img\\{ser}.png");
                    var bitmap = new Bitmap(40, 40);
                    g.DrawImage(image, entry.Key.columna * 50, entry.Key.fila * 50, 40, 40);
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
            autoplayButton.Enabled = false;
            pauseButton.Enabled = true;
            stepButton.Enabled = false;
            autoplayActivado = true;
            hiloSafari.Start();

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            autoplayActivado = false;
            token.Cancel();
            token.Dispose();
            if (hiloSafari.ThreadState == ThreadState.Running)
            {
                Console.WriteLine("DENTRO");
                hiloSafari.Join();
            }
            token = new CancellationTokenSource();
            controller.restartSafari();
            hiloSafari = new(() => autoplay());
            hiloSafari.IsBackground = true;
            stopButton.Enabled = true;
            pauseButton.Enabled = true;
            autoplayButton.Enabled = true;
            stepButton.Enabled = true;
            Refresh();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            autoplayActivado = false;
            pauseButton.Enabled = false;
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
