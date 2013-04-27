using Emulator.Common;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Net.Messages.Game.Approach;
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
