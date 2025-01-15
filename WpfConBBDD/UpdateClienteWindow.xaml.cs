using System;
using System.Windows;
using System.Data.SqlClient;

namespace WpfConBBDD
{
    /// <summary>
    /// Lógica de interacción para UpdateClienteWindow.xaml
    /// </summary>
    public partial class UpdateClienteWindow : Window
    {
        private SqlConnection con;
        public UpdateClienteWindow(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String id = idClienteTextBlock.Text;
                String nombre = nombreClienteTextBox.Text;
                String direccion = direccionClienteTextBox.Text;
                String poblacion = poblacionClienteTextBox.Text;
                String telefono = telefonoClienteTextBox.Text;
                String consulta = "UPDATE Cliente " +
                                  "SET nombre = @nombre, direccion = @direccion, poblacion = @poblacion, telefono = @telefono " +
                                  "WHERE id = @id";
                SqlCommand comando = new SqlCommand(consulta, con);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue ("nombre", nombre);
                comando.Parameters.AddWithValue("direccion", direccion);
                comando.Parameters.AddWithValue("poblacion", poblacion);
                comando.Parameters.AddWithValue("telefono", telefono);
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex) 
            {
                con.Close(); 
            }
            Close();    
        }
    }
}
