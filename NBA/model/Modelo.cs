using NBA.model;
using NBA.model.entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                SELECT id, name, teamLogoUrl
                FROM Team
            ";
            SqlCommand comando = new SqlCommand(consulta, connection);
            Console.WriteLine(connection.ConnectionString);
            connection.Open();
            SqlDataReader reader = comando.ExecuteReader();
            List<ModelTeam> equipos = new List<ModelTeam>();
            while (reader.Read())
            {
                ModelTeam equipo = new ModelTeam();
                equipo.Id = reader.GetInt32(0);
                equipo.Nombre = reader.GetString(1);
                equipo.Logo = reader.GetString(2);
                equipos.Add(equipo);
            } 
            reader.Close();
            connection.Close();
            equipos.ForEach(equipo =>
            {
                equipo.Jugadores = getPlayersByTeam(equipo);
            });
            return equipos;
        }

        /// <summary>
        /// Devuelve los jugadores del equipo que tenga el nombre <c><paramref name="equipo"/></c>
        /// </summary>
        /// <param name="equipo">El nombre del equipo</param>
        /// <returns>Lista con los jugadores del equipo</returns>
        private List<ModelPlayer> getPlayersByTeam(ModelTeam equipo)
        {
             String consulta = @"
                SELECT id, firstName, lastName, headShotUrl, position
                FROM Player
                WHERE team = @nombre
            ";

            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.Parameters.AddWithValue("@nombre", equipo.Nombre);
            connection.Open();
            SqlDataReader reader = comando.ExecuteReader();
            List<ModelPlayer> jugadores = new List<ModelPlayer>();
            // Mientras haya más jugadores por leer
            while (reader.Read())
            {
                ModelPlayer player = new ModelPlayer();
                player.Id = reader.GetInt32(0);
                player.Nombre = reader.GetString(1);
                player.Apellidos = reader.GetString(2);
                player.Imagen = reader.GetString(3);
                player.Posicion = reader.GetString(4);
                player.Equipo = equipo;
                jugadores.Add(player);
            } 
            connection.Close();
            return jugadores;
        }

        /*private ModelTeam getTeamByName(String nombreEquipo)
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

        }*/
    }
}
