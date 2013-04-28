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
// Created on 27/04/2013 at 10:30
#endregion

using System.Collections.Generic;
using Emulator.Common;
using Emulator.Common.Network;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Network.Sync.Messages;
using Emulator.Common.Protocol.Enums;

namespace Emulator.Game.Network.Sync
{
    public class SyncClient : Client
    {
        public Dictionary<string, int> Tickets { get; set; }

        public SyncClient()
        {
            Dispatcher.Register(this);
            Tickets = new Dictionary<string, int>();
        }

        public void UpdateState(ServerStatusEnum state)
        {
            Send(new ServerStatusUpdateMessage(state));
        }

        [MessageHandler(HelloSyncMessage.ID)]
        public void HandleHelloSyncMessage(HelloSyncMessage message)
        {
            Send(new SyncIdentificationMessage(Program.Config.ServerId, Program.Config.SyncPassword));
        }

        [MessageHandler(SyncIdentificationFailedMessage.ID)]
        public void HandleSyncIdentificationFailedMessage(SyncIdentificationFailedMessage message)
        {
            Logger.Error("Can't register to the login server : wrong password.");
        }

        [MessageHandler(SyncIdentificationSuccessMessage.ID)]
        public void HandleSyncIdentificationSuccessMessage(SyncIdentificationSuccessMessage message)
        {
            Logger.Info("Succesfully registered to the login server !");
            UpdateState(ServerStatusEnum.STARTING);
            Program.Start();
        }

        [MessageHandler(ClientTicketMessage.ID)]
        public void HandleClientTicketMessage(ClientTicketMessage message)
        {
            Tickets.Add(message.Ticket, message.AccountId);
        }

        protected override void OnClientDisconnected()
        {
            base.OnClientDisconnected();
            Logger.Error("Login server disconnect.");
            Stop();
        }
    }
}
