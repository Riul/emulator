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
// Created on 27/04/2013 at 18:03
#endregion

using Emulator.Common;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Net.Messages.Game.Approach;
using Emulator.Common.Protocol.Net.Messages.Handshake;
using Emulator.Common.Sql.Tables;
using Emulator.Game.Network;

namespace Emulator.Game.Approach
{
    public class ApproachManager
    {
        private readonly GameClient client;

        public ApproachManager(GameClient client)
        {
            this.client = client;
            client.Dispatcher.Register(this);

            SayHello();
        }

        public void SayHello()
        {
            client.Send(new ProtocolRequired(1505, 1507));
            client.Send(new HelloGameMessage());
        }

        [MessageHandler(AuthenticationTicketMessage.Id)]
        public void HandleAuthenticationTicketMessage(AuthenticationTicketMessage message)
        {
            if (Program.Sync.Tickets.ContainsKey(message.ticket))
            {
                client.Account = AccountsTable.Load(Program.Sync.Tickets[message.ticket]);
                Program.Sync.Tickets.Remove(message.ticket);
                client.Send(new AuthenticationTicketAcceptedMessage());
            }
            else
            {
                client.Send(new AuthenticationTicketRefusedMessage());
                client.Stop();
                Logger.Warning("User trying to connect with an invalid ticket.");
            }
        }
    }
}
