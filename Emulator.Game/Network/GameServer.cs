﻿#region License
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
//     Created on 27/04/2013 at 13:31
// */
#endregion

using System.Collections.Generic;
using System.Net.Sockets;
using Emulator.Common.Network;

namespace Emulator.Game.Network
{
    public class GameServer : Server
    {
        public GameServer() : base(Program.Config.GamePort)
        {
        }

        public List<GameClient> Clients { get; private set; }

        protected override void OnClientConnected(TcpClient client)
        {
            base.OnClientConnected(client);
            GameClient auth = new GameClient(client);
            auth.ClientDisconnected += OnClientDisconnected;
            Clients.Add(auth);
        }

        private void OnClientDisconnected(Client client)
        {
            foreach (var auth in Clients)
            {
                if (auth == client)
                {
                    Clients.Remove(auth);
                    return;
                }
            }
        }
    }
}
