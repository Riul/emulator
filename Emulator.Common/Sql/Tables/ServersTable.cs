#region License
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 26/04/2013 at 17:17
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
