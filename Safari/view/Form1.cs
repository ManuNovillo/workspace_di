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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void paintSeres(Graphics g)
        {
            Dictionary<Position, Ser?> seres = Controller.Safari.getSeres();
            Font font = new Font("Arial", 8);

             foreach (var entry in seres)
             {

                using (Brush brush = new SolidBrush(Color.Black))
                {
                    String texto = entry.Value != null ? entry.Value.ToString() : "";
                    g.DrawString(texto, font, brush, entry.Key.X * 50, entry.Key.Y * 30);
                }
             }
            Update();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            paintSeres(e.Graphics);
        }
    }
}
