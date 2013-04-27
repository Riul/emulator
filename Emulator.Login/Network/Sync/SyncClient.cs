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

using System.Net.Sockets;
using Emulator.Common;
using Emulator.Common.Network;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Network.Sync.Messages;
using Emulator.Common.Protocol.Enums;
using Emulator.Common.Sql.Models;
using Emulator.Common.Sql.Tables;
using Emulator.Login.Managers;

namespace Emulator.Login.Network.Sync
{
    public class SyncClient : Client
    {
        public SyncClient(TcpClient client) : base(client)
        {
            Identified = false;
            Dispatcher.Register(this);
            Send(new HelloSyncMessage());
        }

        public int ServerId { get; private set; }
        public bool Identified { get; private set; }

        public void SendTicket(string ticket, int accountId)
        {
            Send(new ClientTicketMessage(ticket, accountId));
        }

        [MessageHandler(SyncIdentificationMessage.Id)]
        public void HandleSyncIdentificationMessage(SyncIdentificationMessage message)
        {
            if (message.Password == Program.Config.SyncPassword)
            {
                ServerModel server = ServersTable.Load(message.ServerId);
                if (server != null)
                {
                    ServerId = message.ServerId;
                    Identified = true;
                    Send(new SyncIdentificationSuccessMessage());
                    Logger.Info("New game server detected ! (ID : {0})", message.ServerId);
                    return;
                }
            }
            Logger.Warning("A game server is trying to connect with a bad password or a bad ID.");
            Send(new SyncIdentificationFailedMessage());
            Stop();
        }

        [MessageHandler(ServerStatusUpdateMessage.Id)]
        public void HandleServerStatusUpdateMessage(ServerStatusUpdateMessage message)
        {
            if (!Identified)
            {
                Logger.Warning("A game server is trying to update is state without beeing identified.");
                Stop();
            }
            ServersTable.Load(ServerId).Status = message.Status;
            ServersManager.UpdateServer(ServerId);
        }

        protected override void OnClientDisconnected()
        {
            base.OnClientDisconnected();
            if (Identified)
            {
                Logger.Warning("Game server with id {0} disconnected.", ServerId);
                ServersTable.Load(ServerId).Status = ServerStatusEnum.OFFLINE;
                ServersManager.UpdateServer(ServerId);
            }
        }
    }
}
