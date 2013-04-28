using System.Net.Sockets;
using Emulator.Common;
using Emulator.Common.Network;
using Emulator.Common.Protocol.Net.Messages;
using Sniffer.Config;

namespace Sniffer.Network
{
    public abstract class MITMClient : Client
    {
        public Client Server { get; set; }

        protected MITMClient(TcpClient client, bool start = false) : base(client)
        {
            MessageReceived += ClientOnMessageReceived;
            Server = new Client();
            Server.MessageReceived += ServerOnMessageReceived;

            if(start)
                Server.Start(SnifferConfig.Instance.DofusIP, SnifferConfig.Instance.DofusPort);
        }

        protected virtual void ClientOnMessageReceived(object sender, NetworkMessage message)
        {
            if (Parse(message))
            {
                Server.Send(message.MessageId, message.Data);
                Logger.Info("[Sent] {0} : {1}", message.MessageId, message.GetType().Name);
            }
        }

        protected virtual void ServerOnMessageReceived(object sender, NetworkMessage message)
        {
            if (Parse(message))
            {
                Send(message.MessageId, message.Data);
                Logger.Info("[Received] {0} : {1}", message.MessageId, message.GetType().Name);
            }
        }

        protected abstract bool Parse(NetworkMessage message);
    }
}