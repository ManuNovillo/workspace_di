using Safari.controller;

namespace Safari.view
{
    public partial class VentanaInicio : Form
    {
        private Controller controller { get; set; }
        public VentanaInicio(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void confirmarButton_Click(object sender, EventArgs e)
        {
            int filasMinimas = controller.getFilasMinimas();
            int filasMaximas = controller.getFilasMaximas();
            int columnasMinimas = controller.getColumnasMinimas();
            int columnasMaximas = controller.getColumnasMaximas();
            if (filasNumField.Value < filasMinimas || filasNumField.Value > filasMaximas)
            {
                errorLabel.Text = $"El número de filas debe estar entre {filasMinimas} y {filasMaximas}";
                errorLabel.Visible = true;
            }

            else if (columnasNumField.Value < columnasMinimas || columnasNumField.Value > columnasMaximas)
            {
                errorLabel.Text = $"El número de columnas debe estar entre {columnasMinimas} y {columnasMaximas}";
                errorLabel.Visible = true;
            }

            else
            {
                Hide();
                controller.startSafari((int)filasNumField.Value, (int)columnasNumField.Value);
                Close();

            }
        }

    }
}
