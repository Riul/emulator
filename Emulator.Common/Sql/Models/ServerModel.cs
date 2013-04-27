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
// Created on 26/04/2013 at 16:53
#endregion

using Emulator.Common.Protocol.Enums;
using MySql.Data.MySqlClient;

namespace Emulator.Common.Sql.Models
{
    public class ServerModel
    {
        public const string TABLE = "servers";

        public ServerModel()
        {
        }

        public ServerModel(MySqlDataReader reader)
        {
            InitFromData(reader);
        }

        public int Id { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public ServerStatusEnum Status { get; set; }

        public void InitFromData(MySqlDataReader reader)
        {
            Id = (int)reader["id"];
            Ip = (string)reader["ip"];
            Port = (int)reader["port"];
            Status = ServerStatusEnum.OFFLINE;
        }
    }
}
