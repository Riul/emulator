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
