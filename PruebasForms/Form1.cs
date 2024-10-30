namespace PruebasForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MiFormulario_MouseMove(sender, (MouseEventArgs) e);
        }
    }
}
