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
            List<String> seresTexto = controller.getSeres();
            updateLabels();
            foreach (var serTexto in seresTexto)
            {
                var partes = serTexto.Split(' ');
                var tipoSer = partes[0];

                if (!tipoSer.Contains("Vacio"))
                {
                    var fila = int.Parse(partes[1]);
                    var columna = int.Parse(partes[2]);
                    // Dibujar el icono del ser
                    var image = Image.FromFile($"img\\{tipoSer}.png");
                    var bitmap = new Bitmap(40, 40);
                    g.DrawImage(image, columna * 50, fila * 50, 40, 40); // Multiplicar por 50 para separación de 50px en ambos ejes
                }
            }
        }

        private void updateLabels()
        {
            plantasLabel.Text = $"PLANTAS: {controller.getNumeroPlantas()}";
            elefantesLabel.Text = $"ELEFANTES: {controller.getNumeroElefantes()}";
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
            activarAutoplay();

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            pausar();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            step();
        }

        private void diezPasosButton_Click(object sender, EventArgs e)
        {
            hacer10Pasos();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pausar();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activarAutoplay();
        }

        // Examen 2
        private void pasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hacer10Pasos();
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
            checkFinSimulacion();
        }

       

        private void activarAutoplay()
        {
            autoplayButton.Enabled = false;
            diezPasosButton.Enabled = false;
            pauseButton.Enabled = true;
            stepButton.Enabled = false;
            autoplayActivado = true;
            // Empezar solo si es la primera vez que se hace click en autoplay
            if (!hiloAutoplay.IsAlive) hiloAutoplay.Start(); 
        }

        private void pausar()
        {
            autoplayActivado = false;
            pauseButton.Enabled = false;
            diezPasosButton.Enabled = true;
            autoplayButton.Enabled = true;
            stepButton.Enabled = true;
        }

        private void reset()
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
            diezPasosButton.Enabled = true;
            stopButton.Enabled = true;
            pauseButton.Enabled = false;
            autoplayButton.Enabled = true;
            stepButton.Enabled = true;
            Refresh(); // Dibujar otra vez
        }

        private void stop()
        {
            token.Cancel();
            token.Dispose();
            stopButton.Enabled = false;
            pauseButton.Enabled = false;
            autoplayButton.Enabled = false;
            stepButton.Enabled = false;
            resetButton.Enabled = false;
        }

        // Examen 2
        private void hacer10Pasos()
        {
            for (int i = 0; i < 10; i++)
            {
                controller.step();
            }
            // Actualizar ventana después de los 10 pasos
            Refresh();
            checkFinSimulacion();
        }

        /// <summary>
        /// Si la simulacion debe terminar, muestra un messagebox con un mensaje distinto
        /// dependiendo si solo quedan plantas o si no queda ningún ser
        /// </summary>
        private void checkFinSimulacion()
        {
            // Ejercicio 4
            if (controller.simuacionTerminada())
            {
                stopButton.Enabled = false;
                pauseButton.Enabled = false;
                autoplayButton.Enabled = false;
                stepButton.Enabled = false;
                diezPasosButton.Enabled = false;

                if (controller.soloQuedanPlantas())
                {
                    MessageBox.Show("Solo las plantas pueden dominar el mundo");
                }
                else if (controller.noQuedanSeres())
                {
                    MessageBox.Show("Es el Fin del Mundo");
                }
            }
        }
    }
}
