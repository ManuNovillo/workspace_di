using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MVC.model
{
    public class Model
    {
        private SqlConnection con;
        public Model() { 
            String miConexion = ConfigurationManager.ConnectionStrings["WpfConBBDD.Properties.Settings.PruebaWPFConnectionString"].ConnectionString;
            con = new SqlConnection(miConexion);

        }
        public DataTable getAllClientes() {
            String consulta = "SELECT * FROM Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataTable tablaClientes = new DataTable();
            adapter.Fill(tablaClientes);

            return tablaClientes;
        }

        public void inserCliente()
        {

        }
    }
}
