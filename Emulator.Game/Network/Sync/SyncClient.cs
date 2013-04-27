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
//     Created on 27/04/2013 at 10:30
// */
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
        public SyncClient()
        {
            Dispatcher.Register(this);
        }

        public Dictionary<string, int> Tickets { get; set; }

        public void UpdateState(ServerStatusEnum state)
        {
            Send(new ServerStatusUpdateMessage(state));
        }

        [MessageHandler(HelloSyncMessage.Id)]
        public void HandleHelloSyncMessage(HelloSyncMessage message)
        {
            Send(new SyncIdentificationMessage(Program.Config.ServerId, Program.Config.SyncPassword));
        }

        [MessageHandler(SyncIdentificationFailedMessage.Id)]
        public void HandleSyncIdentificationFailedMessage(SyncIdentificationFailedMessage message)
        {
            Logger.Error("Can't register to the login server : wrong password.");
        }

        [MessageHandler(SyncIdentificationSuccessMessage.Id)]
        public void HandleSyncIdentificationSuccessMessage(SyncIdentificationSuccessMessage message)
        {
            Logger.Info("Succesfully registered to the login server !");
            UpdateState(ServerStatusEnum.STARTING);
        }

        [MessageHandler(ClientTicketMessage.Id)]
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
