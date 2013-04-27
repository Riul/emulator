#region License
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
//     Created on 26/04/2013 at 17:17
// */
#endregion

using System.Collections.Generic;
using Emulator.Common.Sql.Models;
using MySql.Data.MySqlClient;

namespace Emulator.Common.Sql.Tables
{
    public class ServersTable
    {
        private static List<ServerModel> cache;

        public static ServerModel[] Load()
        {
            if (cache == null)
            {
                cache = new List<ServerModel>();
                MySqlDataReader reader = SQLManager.ExecuteQuery("SELECT * FROM {0}", ServerModel.TABLE);

                while (reader.Read())
                {
                    cache.Add(new ServerModel(reader));
                }
                reader.Close();
            }
            return cache.ToArray();
        }

        public static ServerModel Load(int id)
        {
            ServerModel[] servers = Load();
            foreach (var server in servers)
            {
                if (server.Id == id)
                    return server;
            }
            return null;
        }
    }
}
