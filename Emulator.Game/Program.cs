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
using System.Threading;
using Emulator.Common;
using Emulator.Common.Protocol.Enums;
using Emulator.Game.Config;
using Emulator.Game.Network;
using Emulator.Game.Network.Sync;

namespace Emulator.Game
{
    class Program
    {
        private static bool running;
        public static GameConfig Config { get; private set; }
        public static SyncClient Sync { get; private set; }
        public static GameServer GameServer { get; private set; }

        static void Main(string[] args)
        {
#if DEBUG
            Thread.Sleep(5000);
#endif

            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
            Config = new GameConfig();
            Sync = new SyncClient();

            if (Sync.Start(Config.SyncIp, Config.SyncPort))
            {

                running = true;

                while (running)
                {
                    string line = Console.ReadLine().Trim();
                    if (line == "stop")
                    {
                        Sync.UpdateState(ServerStatusEnum.OFFLINE);
                        Sync.Stop();
                        Config.Save();
                        running = false;
                    }
                }
            }
            else
            {
                Logger.Error("Unable to connect to the login server.");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void Start()
        {
            GameServer = new GameServer();
            GameServer.Start();
            Logger.Info("Game server started on port {0}", Config.GamePort);
            Sync.UpdateState(ServerStatusEnum.ONLINE);
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }
    }
}
