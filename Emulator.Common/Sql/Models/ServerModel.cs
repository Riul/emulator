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
//     Created on 26/04/2013 at 16:53
// */
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
