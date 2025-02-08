using System.Configuration;
using System.Data.SqlClient;

namespace NBA.model
{
    internal static class Conexion
    {
        private static SqlConnection connection;

        internal static SqlConnection Connection { get { return connection; } }

        static Conexion()
        {
            // PONER 1 EN CLASE
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NBA.Properties.Settings.nbadbConnectionString"].ConnectionString);
        }
    }
}
