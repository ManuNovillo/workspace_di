using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NBAmodel
{
    public class Modelo
    {
        private SqlConnection connection;

        public Modelo() {
            String miConexion = ConfigurationManager.ConnectionStrings["NBA.Properties.Settings.nbadbConnectionString"].ConnectionString;
            connection = new SqlConnection(miConexion);
        }

        public DataTable getAllTeams()
        {
            String consulta = @"
                SELECT *
                FROM Team
            ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, connection);
            DataTable teamsTable = new DataTable();
            dataAdapter.Fill(teamsTable);
            return teamsTable;
        }

        public DataTable getPlayersByTeam(String nombreEquipo)
        {
             String consulta = @"
                SELECT *
                FROM Player
                WHERE team = @nombre
            ";
            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.Parameters.AddWithValue("@nombre", nombreEquipo);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            DataTable teamsTable = new DataTable();
            dataAdapter.Fill(teamsTable);
            return teamsTable;
        }
    }
}
