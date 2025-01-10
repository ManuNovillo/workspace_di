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
            muestraPedidosCliente();

        }

        private void muestraPedidos()
        {
            String consulta = "SELECT CONCAT(codigoCliente, ' | ', fecha, ' | ', formapago) infopedido FROM Pedido";
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
            if (pedidosListBox.SelectedValue is null)
            {
                MessageBox.Show("Selecciona un pedido");
            }
            else
            {
                eliminarPedido(); 
            }
        }

        private void eliminarPedido()
        {

        }
    }
}
