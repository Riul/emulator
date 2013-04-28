using System;
using System.Net.Sockets;
using Emulator.Common.Protocol.Net.Messages;
using Sniffer.Config;

namespace Sniffer.Network
{
    public sealed class LoginClient : MITMClient
    {
        public LoginClient(TcpClient client) : base(client, true)
        {
        }

        protected override bool Parse(NetworkMessage message)
        {
            if (message is SelectedServerDataMessage)
            {
                SelectedServerDataMessage serverData = (SelectedServerDataMessage)message;
                Program.MITM.Tickets.Add(serverData.Ticket, Tuple.Create(serverData.Address, (int)serverData.Port));

                serverData.Address = "127.0.0.1";
                serverData.Port = (ushort)SnifferConfig.Instance.GamePort;
                Send(serverData);
                Stop();
                return false;
            }
            return true;
        }
    }
}
