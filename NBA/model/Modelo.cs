using NBA.model;
using NBA.model.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Documents;

namespace NBAmodel
{
    public class Modelo
    {
        private SqlConnection connection;

        public Modelo() {
            connection = Conexion.Connection;
        }

        public List<ModelTeam> getAllTeams()
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

        public List<ModelPlayer> getPlayersByTeam(String nombreEquipo)
        {
             String consulta = @"
                SELECT id, firstName, lastName, headShotUrl 
                FROM Player
                WHERE team = @nombre
            ";

            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.Parameters.AddWithValue("@nombre", nombreEquipo);
            SqlDataReader reader = comando.ExecuteReader();
            List<ModelPlayer> jugadores = new List<ModelPlayer>();
            while (reader.Read())
            {
                ModelPlayer player = new ModelPlayer();
                player.Id = reader.GetInt32(0);
                player.Nombre = reader.GetString(1);
                player.Apellidos = reader.GetString(2);
                player.Imagen = reader.GetString(3);
                player.Equipo = getTeamByName(nombreEquipo);

            } 
            return jugadores;
        }

        private ModelTeam getTeamByName(String nombreEquipo)
        {
             String consulta = @"
                SELECT id, name, teamLogoUrl 
                FROM Team
                WHERE name = @nombre
            ";

            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.Parameters.AddWithValue("@nombre", nombreEquipo);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                ModelPlayer player = new ModelPlayer();
                player.Id = reader.GetInt32(0);
                player.Nombre = reader.GetString(1);
                player.Apellidos = reader.GetString(2);
                player.Imagen = reader.GetString(3);
                player.Equipo = getTeamByName(nombreEquipo);
            } 
            return null;

        }
    }
}
