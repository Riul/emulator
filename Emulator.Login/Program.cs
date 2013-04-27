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
// Created on 26/04/2013 at 16:34
#endregion

using System;
using Emulator.Common;
using Emulator.Common.Sql;
using Emulator.Login.Config;
using Emulator.Login.Network;
using Emulator.Login.Network.Sync;

namespace Emulator.Login
{
    class Program
    {
        public static AuthServer Server { get; private set; }
        public static SyncServer SyncServer { get; private set; }
        public static LoginConfig Config { get; private set; }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
            Config = new LoginConfig();

            if (SQLManager.Init(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPassword))
            {
                Logger.Info("SQLManager initialized!");
            }

            SyncServer = new SyncServer();
            SyncServer.Start();
            Logger.Info("Syncronization server stated on port {0}", Config.SyncPort);

            Server = new AuthServer();
            Server.Start();
            Logger.Info("Authentification server stated on port {0}", Config.LoginPort);

            while (true)
            {
                Console.Read();
            }
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
