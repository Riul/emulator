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
//     Created on 26/04/2013 at 19:13
// */
#endregion

using System.Collections.Generic;
using System.Net.Sockets;
using Emulator.Common;
using Emulator.Common.Network;
using Emulator.Common.Protocol.Enums;
using Emulator.Common.Sql.Tables;

namespace Emulator.Login.Network.Sync
{
    public class SyncServer : Server
    {
        public SyncServer() : base(Program.Config.SyncPort)
        {
            Clients = new List<SyncClient>();
        }

        public List<SyncClient> Clients { get; private set; }

        public SyncClient GetServer(int id)
        {
            foreach (var client in Clients)
            {
                if (client.ServerId == id)
                    return client;
            }
            return null;
        }

        protected override void OnClientConnected(TcpClient client)
        {
            base.OnClientConnected(client);
            SyncClient auth = new SyncClient(client);
            auth.ClientDisconnected += OnClientDisconnected;
            Clients.Add(auth);
        }

        private void OnClientDisconnected(Client client)
        {
            foreach (var auth in Clients)
            {
                if (auth == client)
                {
                    SyncClient c = (SyncClient) client;
                    if (c.Identified)
                    {
                        Logger.Warning("Game server with id {0} disconnected.", c.ServerId);
                        ServersTable.Load(c.ServerId).Status = ServerStatusEnum.OFFLINE;
                    }
                    Clients.Remove(auth);
                    return;
                }
            }
        }
    }
}
