using Safari.controller;
using Safari.model.position;
using Safari.model.seres;

namespace Safari
{
    public partial class VentanaSafari : Form
    {
        private Thread hiloAutoplay;

        private CancellationTokenSource token;

        private bool autoplayActivado;
        private Controller controller { get; set; }
        public VentanaSafari(Controller controller)
        {
            this.controller = controller;
            token = new();
            InitializeComponent();
            hiloAutoplay = new(() => autoplay());
            pauseButton.Enabled = false;
            hiloAutoplay.IsBackground = true;
        }
        /// <summary>
        /// Pinta todos los elementos del safari, es decir, los seres y las labels
        /// </summary>
        private void paintSafari(Graphics g)
        {
            Dictionary<Posicion, Ser?> seres = controller.getSeres();
            updateLabels();
            foreach (var entry in seres)
            {
                Ser? ser = entry.Value;

                if (ser != null)
                {
                    // Dibujar el icono del ser
                    var image = Image.FromFile($"..\\..\\..\\view\\img\\{ser}.png");
                    var bitmap = new Bitmap(40, 40);
                    g.DrawImage(image, entry.Key.columna * 50, entry.Key.fila * 50, 40, 40); // Multiplicar por 50 para separación de 50px en ambos ejes
                }
            }
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
            if(!hiloAutoplay.IsAlive) hiloAutoplay.Start(); // Empezar solo si es la primera vez que se hace click en autoplay

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            autoplayActivado = false;
            token.Cancel();
            token.Dispose();
            if (hiloAutoplay.IsAlive) hiloAutoplay.Join(); // Si el hilo se está ejecutando, esperar a que termine
            // Volver a instanciar todo lo relacionado con el hilo de autoplay para evitar choques con la anterior ejecución
            token = new CancellationTokenSource();
            controller.restartSafari();
            hiloAutoplay = new(() => autoplay());
            hiloAutoplay.IsBackground = true;

            stopButton.Enabled = true;
            pauseButton.Enabled = false;
            autoplayButton.Enabled = true;
            stepButton.Enabled = true;
            Refresh(); // Dibujar otra vez
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            autoplayActivado = false;
            pauseButton.Enabled = false;
            autoplayButton.Enabled = true;
            stepButton.Enabled = true;
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
