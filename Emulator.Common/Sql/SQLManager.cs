﻿#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 24/04/2013 at 16:35
// */
#endregion

using System;
using MySql.Data.MySqlClient;

namespace Emulator.Common.Sql
{
    public static class SQLManager
    {
        public static readonly object Locker = new object();

        private static MySqlConnection connection;
        private static bool initialized;

        public static string Ip;
        public static string Database;
        public static string Username;
        public static string Password;

        /// <summary>
        /// Initializes the Mysql connection
        /// </summary>
        public static bool Init(string ip, string database, string username, string password)
        {
            if (!initialized)
            {
                Ip = ip;
                Database = database;
                Username = username;
                Password = password;
                connection = new MySqlConnection(string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", ip, database, username, password));
                initialized = true;
                return Open();
            }
            throw new Exception("SQLManager already initialized");
        }

        /// <summary>
        /// Opens the Mysql connection
        /// </summary>
        public static bool Open()
        {
            lock (Locker)
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 1045:
                            Logger.Error("Cannot connect to database {0} on {1}. Invalid username or password", Database, Ip);
                            break;
                        default:
                            Logger.Error("Cannot connect to database {0} on {1}. Error {2}", Database, Ip, ex.Number);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("Cannot connect to database {0} on {1}.", ex, Database, Ip);
                }
                return false;
            }
        }

        /// <summary>
        /// Closes the Mysql connection
        /// </summary>
        public static void Close()
        {
            lock (Locker)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
        }

        /// <summary>
        /// Opens the connection, executes the query and closes the connection
        /// </summary>
        public static void ExecuteNonQuery(string query, params object[] pars)
        {
            lock (Locker)
            {
                MySqlCommand command = new MySqlCommand(string.Format(query, pars), connection);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Opens the connection and executes the query
        /// </summary>
        /// <returns>Query's result</returns>
        /// <remarks>Don't forget to close the connection after using the MySqlDataReader</remarks>
        public static MySqlDataReader ExecuteQuery(string query, params object[] pars)
        {
            lock (Locker)
            {
                MySqlCommand command = new MySqlCommand(string.Format(query, pars), connection);
                return command.ExecuteReader();
            }
        }
    }
}
