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
//     Created on 26/04/2013 at 16:34
// */
#endregion

using System;
using System.Threading;
using Emulator.Common;
using Emulator.Common.Protocol.Enums;
using Emulator.Game.Config;
using Emulator.Game.Network.Sync;

namespace Emulator.Game
{
    class Program
    {
        private static bool running;
        public static GameConfig Config { get; private set; }
        public static SyncClient Sync { get; private set; }

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
            //Start game server
            Sync.UpdateState(ServerStatusEnum.ONLINE);
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }
    }
}
