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
// Created on 26/04/2013 at 19:42
#endregion

using Emulator.Common.Config;

namespace Emulator.Login.Config
{
    public class LoginConfig : ConfigFile
    {
        public const string FILE_PATH = "LoginConfig.txt";

        public string DbHost { get; set; }
        public string DbName { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public int LoginPort { get; set; }
        public int SyncPort { get; set; }
        public string SyncPassword { get; set; }

        public LoginConfig() : base(FILE_PATH)
        {
            DbHost = GetValue("db_host", "127.0.0.1");
            DbName = GetValue("db_name", "emulator");
            DbUser = GetValue("db_user", "root");
            DbPassword = GetValue("db_password");
            LoginPort = int.Parse(GetValue("login_port", "5554"));
            SyncPort = int.Parse(GetValue("sync_port", "5556"));
            SyncPassword = GetValue("sync_password", "password");
            Save();
        }
    }
}
