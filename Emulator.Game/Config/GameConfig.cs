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
//     Created on 27/04/2013 at 10:30
// */
#endregion

using Emulator.Common.Config;

namespace Emulator.Game.Config
{
    public class GameConfig : ConfigFile
    {
        public const string FILE_PATH = "GameConfig.txt";

        public GameConfig() : base(FILE_PATH)
        {
            DbHost = GetValue("db_host", "127.0.0.1");
            DbName = GetValue("db_name", "emulator");
            DbUser = GetValue("db_user", "root");
            DbPassword = GetValue("db_password");
            GamePort = int.Parse(GetValue("game_port", "5554"));
            ServerId = int.Parse(GetValue("server_id", "1"));
            SyncIp = GetValue("sync_ip", "127.0.0.1");
            SyncPort = int.Parse(GetValue("sync_port", "5556"));
            SyncPassword = GetValue("sync_password", "password");
            Save();
        }

        public string DbHost { get; set; }
        public string DbName { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }

        public int GamePort { get; set; }
        public int ServerId { get; set; }

        public string SyncIp { get; set; }
        public int SyncPort { get; set; }
        public string SyncPassword { get; set; }
    }
}
