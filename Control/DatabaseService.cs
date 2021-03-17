using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Dapper;
using LogiranjeApp.Models;
using MySql.Data.MySqlClient;

namespace LogiranjeApp.Control
{
    public class DatabaseService
    {
        private static readonly string _conString = "Server=127.0.0.1;Port=3306;Database=logiranje;Uid=root;Pwd=1234;";

        private static void Exec(string query)
        {
            using (IDbConnection conn = new MySqlConnection(_conString))
            {
                //vpisi query string
                conn.Execute(query);
            }
        }

        private static void Exec<T>(string query, T param)
        {
            using (IDbConnection conn = new MySqlConnection(_conString))
            {
                //vpisi query string
                conn.Execute(query, param);
            }
        }

        private static List<T> Select<T>(string query)
        {
            using (IDbConnection conn = new MySqlConnection(_conString))
            {
                //vpisi query string
                List<T> items = conn.Query<T>(query).ToList();


                return items;
            }
        }

        private static List<T> Select<T, U>(string query, U param)
        {
            using (IDbConnection conn = new MySqlConnection(_conString))
            {
                //vpisi query string
                List<T> items = conn.Query<T>(query, param).ToList();


                return items;
            }
        }

        #region GET

        public static List<User> GetUsers()
        {
            string query = "SELECT * FROM users;";

            return Select<User>(query);
        }

        public static List<User> GetUsers(int id)
        {
            string query = "SELECT * FROM users WHERE idUsers = @id";

            return Select<User, dynamic>(query, new { id });
        }

        public static List<Location> GetLocations()
        {
            string query = "SELECT * FROM locations;";

            return Select<Location>(query);
        }

        public static List<Log> GetLogs()
        {
            string query = "SELECT * FROM logs;";

            return Select<Log>(query);
        }

        public static List<Location> GetLocations(int id)
        {
            string query = "SELECT * FROM locations WHERE idLocations = @id;";

            return Select<Location, dynamic>(query, new { id });
        }

        public static List<Log> GetLogLast(int idUsers, int idLocations)
        {
            string query = "SELECT * FROM logs WHERE idUsers = @idUsers AND idLocations = @idLocations ORDER BY logTime DESC LIMIT 1;";

            return Select<Log, dynamic>(query, new { idUsers, idLocations });
        }

        #endregion

        #region POST

        public static string PostUser(User user)
        {
            string query = "INSERT INTO users (idUsers, name, lastName)" +
                            "VALUES (@id, @name, @lastName)";

            Exec<dynamic>(query, new { id = user.IdUsers, name = user.Name, lastName = user.LastName });
            return "Uspesno!";
        }


        public static int PostUser(UserNoId user, int id)
        {
            string query = "INSERT INTO users (idUsers, name, lastName)" +
                            "VALUES (@id, @name, @lastName)";

            Exec<dynamic>(query, new { id, name = user.Name, lastName = user.LastName });
            return id;
        }

        public static string PostLogs(LogNoId log)
        {
            string query = "INSERT INTO logs (idLocations, idUsers, logTime, idLogType)" +
                        "VALUES (@idLocations, @idUsers, @logTime, @idLogType)";

            Exec<dynamic>(query, new { idLocations = log.IdLocations, idUsers = log.IdUsers, logTime = DateTime.Now, idLogType = log.IdLogType });
            return "Uspesno!";
        } 

        #endregion
    }
}