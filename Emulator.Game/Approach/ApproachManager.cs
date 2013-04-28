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

using System;
using Emulator.Common;
using Emulator.Common.Extentions;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Net.Messages.Game.Approach;
using Emulator.Common.Protocol.Net.Messages.Game.Basic;
using Emulator.Common.Protocol.Net.Messages.Game.Character.Choice;
using Emulator.Common.Protocol.Net.Messages.Handshake;
using Emulator.Common.Protocol.Net.Messages.Secure;
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

        [MessageHandler(AuthenticationTicketMessage.ID)]
        public void HandleAuthenticationTicketMessage(AuthenticationTicketMessage message)
        {
            if (Program.Sync.Tickets.ContainsKey(message.Ticket))
            {
                client.Account = AccountsTable.Load(Program.Sync.Tickets[message.Ticket]);
                Program.Sync.Tickets.Remove(message.Ticket);
                client.Send(new AuthenticationTicketAcceptedMessage());
                client.Send(new BasicTimeMessage(DateTime.Now.ToUnixTimestamp(), 7200));
                client.Send(new ServerSettingsMessage("fr", 0, 0));

                //I have no idea of what this array means, but that's what the officials servers send me.
                client.Send(new ServerOptionalFeaturesMessage(new short[] {1, 2, 3, 4, 5, 6}));
                client.Send(new AccountCapabilitiesMessage(client.Account.Id, false, 32767, 32767, 0));
                client.Send(new TrustStatusMessage(true));
            }
            else
            {
                client.Send(new AuthenticationTicketRefusedMessage());
                client.Stop();
                Logger.Warning("User trying to connect with an invalid ticket.");
            }
        }

        [MessageHandler(CharactersListRequestMessage.ID)]
        public void HandleCharactersListRequestMessage(CharactersListRequestMessage message)
        {
        }
    }
}
