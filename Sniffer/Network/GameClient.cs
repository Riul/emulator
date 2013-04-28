using System;
using System.Net.Sockets;
using Emulator.Common.Protocol.Net.Messages;
using Emulator.Common.Protocol.Net.Messages.Game.Approach;
using Emulator.Common.Protocol.Net.Messages.Handshake;

namespace Sniffer.Network
{
    public class GameClient : MITMClient
    {
        public GameClient(TcpClient client) : base(client)
        {
            Send(new ProtocolRequired());
            Send(new HelloGameMessage());
        }

        protected override bool Parse(NetworkMessage message)
        {
            if (message is HelloGameMessage || message is ProtocolRequired)
            {
                return false;
            }
            if(message is AuthenticationTicketMessage)
            {
                AuthenticationTicketMessage ticket = (AuthenticationTicketMessage) message;
                if (Program.MITM.Tickets.ContainsKey(ticket.Ticket))
                {
                    Tuple<string, int> address = Program.MITM.Tickets[ticket.Ticket];
                    Server.Start(address.Item1, address.Item2);
                    Program.MITM.Tickets.Remove(ticket.Ticket);
                }
                else
                {
                    Stop();
                }
            }
            return true;
        }
    }
}
