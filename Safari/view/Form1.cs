using Safari.controller;
using Safari.model.position;
using Safari.model.seres;

namespace Safari
{
    public partial class Form1 : Form
    {
        private Controller Controller { get; set; }
        public Form1(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void paintSeres(Graphics g)
        {
            Dictionary<Position, Ser?> seres = Controller.safari.getSeres();
            Font font = new Font("Arial", 8);

            foreach (var entry in seres)
            {
                //String texto = entry.Value != null ? entry.Value.ToString() : "";
                //g.DrawString(texto, font, brush,entry.Key.X * 50, entry.Key.Y * 50 );
                Ser? ser = entry.Value;
                if (ser != null)
                {
                    var image = Image.FromFile($"..\\..\\..\\view\\img\\{ser.ToString()}.png");
                    var bitmap = new Bitmap(40, 40);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, entry.Key.columna * 50, entry.Key.fila * 50, 40, 40);
                }
            }
            Update();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            paintSeres(e.Graphics);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void button4_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e) { }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
