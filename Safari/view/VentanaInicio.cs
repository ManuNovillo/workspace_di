using Safari.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safari.view
{
    public partial class VentanaInicio : Form
    {
        private Controller Controller {  get; set; }
        public VentanaInicio(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void confirmarButton_Click(object sender, EventArgs e)
        {
            Hide();
            Controller.startSafari((int) filasNumField.Value, (int) columnasNumField.Value);
            Close();
        }
    }
}
