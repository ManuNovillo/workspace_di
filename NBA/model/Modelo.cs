using NBA.model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NBAmodel
{
    public class Modelo
    {
        private SqlConnection connection;

        public Modelo() {
            connection = Conexion.Connection;
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
