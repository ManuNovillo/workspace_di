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
            List<ModelTeam> equipos = new List<ModelTeam>();
            String consulta = @"
                SELECT id, name, teamLogoUrl
                FROM Team
            ";
            SqlCommand comando = new SqlCommand(consulta, connection);
            Console.WriteLine(connection.ConnectionString);
            try
            {
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    // Hago lo de reader[numero] as String porque por algún motivo
                    // al usar reader.GetString(numero), si en la BBDD
                    // hay null, explota, lo cual creo que no tiene sentido.
                    // El caso es que al castear a String se hace un null check según tengo entendido
                    // por lo que no explota
                    ModelTeam equipo = new ModelTeam();
                    equipo.Id = reader.GetInt32(0);
                    equipo.Nombre = reader[1] as String;
                    equipo.Logo = reader[2] as String;
                    equipos.Add(equipo);
                }
                reader.Close();
                connection.Close();
                equipos.ForEach(equipo =>
                {
                    equipo.Jugadores = getPlayersByTeam(equipo);
                });
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message); 
                Console.WriteLine(ex.StackTrace); 
            }

            return equipos;
        }


        /// <summary>
        /// Actualiza en la base de datos el jugador especificado
        /// </summary>
        /// <param name="player">El jugador a actualizar</param>
        /// <returns><c>true</c> si la actualización ha ido bien, <c>false</c> si no</returns>
        public bool updatePlayer(ModelPlayer player)
        {
            String sql = @"
                UPDATE Player
                SET firstName = @nombre,
                    lastName = @apellidos,
                    position = @position,
                    team = @nombreEquipo
                WHERE id = @id
            ";
            SqlCommand updateCommand = new SqlCommand(sql, connection);
            updateCommand.Parameters.AddWithValue("@id", player.Id);
            updateCommand.Parameters.AddWithValue("@nombre", player.Nombre);
            updateCommand.Parameters.AddWithValue("@apellidos", player.Apellidos);
            updateCommand.Parameters.AddWithValue("@position", player.Posicion);
            updateCommand.Parameters.AddWithValue("@nombreEquipo", player.Equipo.Nombre);

            Console.WriteLine(player.Equipo.Nombre);
            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool updateEquipo(ModelTeam team, String nombreViejo)
        {
            updatePlayersTeam(nombreViejo, team.Nombre);
            String sql = @"
                UPDATE Team
                SET name = @nombre
                WHERE id = @id
            ";
            SqlCommand updateCommand = new SqlCommand(sql, connection);
            updateCommand.Parameters.AddWithValue("@id", team.Id);
            updateCommand.Parameters.AddWithValue("@nombre", team.Nombre);

            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Actualiza la tabla Player y cambia todos los valores del campo team 
        /// que tengan el valor <c><paramref name="nombreViejo"/></c>
        /// a <c><paramref name="nombreNuevo"/></c>
        /// </summary>
        /// <param name="nombreViejo"></param>
        /// <param name="nombreNuevo"></param>
        /// <returns></returns>
        private bool updatePlayersTeam(String nombreViejo, String nombreNuevo)
        {
            String sql = @"
                UPDATE Player
                SET team = @nombreNuevo
                WHERE team = @nombreViejo
            ";
            SqlCommand updateCommand = new SqlCommand(sql, connection);
            updateCommand.Parameters.AddWithValue("@nombreNuevo", nombreNuevo);
            updateCommand.Parameters.AddWithValue("@nombreViejo", nombreViejo);

            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
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
                WHERE team = @nombreEquipo
            ";

            SqlCommand comando = new SqlCommand(consulta, connection);
            comando.Parameters.AddWithValue("@nombreEquipo", equipo.Nombre);
            List<ModelPlayer> jugadores = new List<ModelPlayer>();
            try
            {
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                // Mientras haya más jugadores por leer
                while (reader.Read())
                {
                    // Hago lo de reader[numero] as String porque por algún motivo
                    // al usar reader.GetString(numero), si en la BDD
                    // hay null, explota, lo cual creo que no tiene sentido, pues no veo el problema en devolver un null
                    // si eso es lo que hay en la BDD.
                    // El caso es que al castear a String se hace un null check según tengo entendido
                    // por lo que no explota
                    ModelPlayer player = new ModelPlayer();
                    player.Id = reader.GetInt32(0);
                    player.Nombre = reader[1] as String;
                    player.Apellidos = reader[2] as String;
                    player.Imagen = reader[3] as String;
                    player.Posicion = reader[4] as String;
                    player.Equipo = equipo;
                    jugadores.Add(player);
                }
                connection.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message); 
                Console.WriteLine(ex.StackTrace); 
            }
            
            return jugadores;
        }


        public int getNewId()
        {
            String query = @"
                SELECT max(id)+1 
                FROM Player
            ";
            SqlCommand comando = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                int newId = (int) comando.ExecuteScalar();
                connection.Close();
                return newId;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool insertPlayer(ModelPlayer modelPlayer)
        {
            String sql = @"
                INSERT INTO Player (id, firstName, lastName, position, team)
                VALUES (@id, @nombre, @apellidos, @posicion, @equipo)
            ";

            SqlCommand insertCommand = new SqlCommand(sql, connection);
            insertCommand.Parameters.AddWithValue("@id", modelPlayer.Id);
            insertCommand.Parameters.AddWithValue("@nombre", modelPlayer.Nombre);
            insertCommand.Parameters.AddWithValue("@apellidos", modelPlayer.Apellidos);
            insertCommand.Parameters.AddWithValue("@posicion", modelPlayer.Posicion);
            insertCommand.Parameters.AddWithValue("@equipo", modelPlayer.Equipo.Nombre);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }

        public bool deletePlayer(ModelPlayer modelPlayer)
        {
            var sql = @"
                DELETE FROM Player
                WHERE id = @id
            ";

            SqlCommand deleteCommand = new SqlCommand( sql, connection);
            deleteCommand.Parameters.AddWithValue("@id", modelPlayer.Id);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }
    }
}
