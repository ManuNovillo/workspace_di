using Safari.controller;
using Safari.model.position;
using Safari.model.seres;

namespace Safari
{
    public partial class Form1 : Form
    {
        private Controller Controller {  get; set; }
        public Form1(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
            paintSeres();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void paintSeres()
        {
            Dictionary<Position, Ser?> seres = Controller.Safari.getSeres();
            foreach (var entry in seres)
            {
                Console.WriteLine("DADAD");
                Label ser = new Label();
                String texto = entry.Value.GetType().Name;
                ser.AutoSize = true;
                Position pos = entry.Key;
                ser.Location = new Point(pos.X * 30, pos.Y * 30);
                ser.Size = new Size(186, 15);
                ser.TabIndex = 6;
                ser.Text = texto == null ? "" : texto;

            }
        }
    }
}
