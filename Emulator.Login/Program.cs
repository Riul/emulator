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
