using System;
using System.Configuration;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace WpfConBBDD
{
    public partial class MainWindow : Window
    {
        private SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
            String miConexion = ConfigurationManager.ConnectionStrings["WpfConBBDD.Properties.Settings.PruebaWPFConnectionString"].ConnectionString;
            con = new SqlConnection(miConexion);
            muestraCliente();
            muestraPedidos();
        }

        public void muestraCliente()
        {
            String consulta = "SELECT * FROM Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            using (adapter)
            {
                DataTable tablaClientes = new DataTable();
                adapter.Fill(tablaClientes);
                clientesListBox.ItemsSource = tablaClientes.DefaultView;
                clientesListBox.SelectedValuePath = "Id";
                clientesListBox.DisplayMemberPath = "nombre";
            }
        }

        private void muestraPedidosCliente()
        {
            String consulta = "SELECT * FROM Pedido p JOIN Cliente c ON p.codigoCliente = c.id WHERE c.id = @clienteid";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            using (adapter)
            {
                comando.Parameters.AddWithValue("@clienteid", clientesListBox.SelectedValue);
                DataTable tablaPedidos = new DataTable();
                adapter.Fill(tablaPedidos);
                pedidosClienteListBox.ItemsSource = tablaPedidos.DefaultView;
                pedidosClienteListBox.SelectedValuePath = "Id";
                pedidosClienteListBox.DisplayMemberPath = "fecha";
            }
        }

        private void clientesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (clientesListBox.SelectedValue != null)
            {
                muestraPedidosCliente();
            }
        }

        private void muestraPedidos()
        {
            String consulta = "SELECT Id, CONCAT(codigoCliente, ' | ', fecha, ' | ', formapago) infopedido FROM Pedido";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            using (adapter)
            {
                DataTable tablaPedidos = new DataTable();
                adapter.Fill(tablaPedidos);
                pedidosListBox.ItemsSource=tablaPedidos.DefaultView;
                pedidosListBox.SelectedValuePath="Id";
                pedidosListBox.DisplayMemberPath = "infopedido";
            }
        }

        private void eliminaPedidoButton_Click(object sender, RoutedEventArgs e)
        {
            if (pedidosListBox.SelectedValue is null) MessageBox.Show("Selecciona un pedido");
            else eliminarPedido(); 
        }

        private void eliminarPedido()
        {
            String consulta = "DELETE FROM Pedido WHERE id = @idPedido";
            SqlCommand comando = new SqlCommand(consulta, con);
            comando.Parameters.AddWithValue("@idPedido", pedidosListBox.SelectedValue);
            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine(ex.StackTrace);
            }
            muestraPedidos();
        }

        private void pedidosListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MessageBox.Show(pedidosListBox.SelectedValue?.ToString());
        }

        private void insertClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (insertClientTextBox.Text.Equals(""))
            {
                MessageBox.Show("NO HAY NOMBRE");
            }
            else
            {
                insertarCliente();
            }
        }

        private void insertarCliente()
        {
            String consulta = "INSERT INTO Cliente(nombre) VALUES (@nombre)";
            SqlCommand command = new SqlCommand(consulta, con);
            command.Parameters.AddWithValue("@nombre", insertClientTextBox.Text);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine(ex.StackTrace);
            }
            muestraCliente();
        }

        private void deleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientesListBox.SelectedValue is null) MessageBox.Show("Selecciona un cliente");
            else eliminarCliente(); 

        }

        private void eliminarCliente()
        {
            String consulta = "DELETE FROM Cliente WHERE id = @idCliente";
            SqlCommand comando = new SqlCommand(consulta, con);
            comando.Parameters.AddWithValue("@idCliente", clientesListBox.SelectedValue);
            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine(ex.StackTrace);
            }
            muestraCliente();
        }

        private void updateClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientesListBox.SelectedValue is null) MessageBox.Show("Selecciona un cliente");
            else mostrarVentanaUpdate(); 
        }

        private void mostrarVentanaUpdate()
        {
            UpdateClienteWindow updateClienteWindow = new UpdateClienteWindow(con);
            String consulta = "SELECT * FROM Cliente WHERE id = @clienteid";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            using (adapter)
            {
                comando.Parameters.AddWithValue("@clienteid", clientesListBox.SelectedValue);
                DataTable tablaPedidos = new DataTable();
                adapter.Fill(tablaPedidos);
                updateClienteWindow.idClienteTextBlock.Text = tablaPedidos.Rows[0]["id"].ToString();
                updateClienteWindow.nombreClienteTextBox.Text = tablaPedidos.Rows[0]["nombre"].ToString();
                updateClienteWindow.direccionClienteTextBox.Text = tablaPedidos.Rows[0]["direccion"].ToString();
                updateClienteWindow.poblacionClienteTextBox.Text = tablaPedidos.Rows[0]["poblacion"].ToString();
                updateClienteWindow.telefonoClienteTextBox.Text = tablaPedidos.Rows[0]["telefono"].ToString();
            }
            updateClienteWindow.ShowDialog();
            muestraCliente();
        }
    }
}
