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
// Created on 26/04/2013 at 19:13
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
        public List<SyncClient> Clients { get; private set; }

        public SyncServer() : base(Program.Config.SyncPort)
        {
            Clients = new List<SyncClient>();
        }

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
