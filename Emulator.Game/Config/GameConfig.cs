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
// Created on 27/04/2013 at 10:30
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
