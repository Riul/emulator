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
//     Created on 26/04/2013 at 17:42
// */
#endregion

using System;
using System.Text;
using Emulator.Common;
using Emulator.Common.Cryptography;
using Emulator.Common.IO;
using Emulator.Common.Network.Dispatching;
using Emulator.Common.Protocol.Enums;
using Emulator.Common.Protocol.Net.Messages.Connection;
using Emulator.Common.Protocol.Net.Messages.Handshake;
using Emulator.Common.Sql.Models;
using Emulator.Common.Sql.Tables;
using Emulator.Login.Network;

namespace Emulator.Login.Managers
{
    public class AuthentificationManager
    {
        public const string CURRENT_VERSION = "2.11.1.2.72101";

        private readonly AuthClient client;
        private readonly ServersManager servers;
        private IdentificationMessage message;
        private string salt;

        public AuthentificationManager(AuthClient client)
        {
            this.client = client;
            servers = new ServersManager(client);
            client.Dispatcher.Register(this);

            SayHello();
        }

        public void SayHello()
        {
            salt = GenerateSalt();
            client.Send(new ProtocolRequired(1505, 1507));
            client.Send(new HelloConnectMessage(salt, new byte[256]));
        }

        public void CheckAccount()
        {
            if (message == null)
            {
                Logger.Error("Trying to check an account without identification message.");
                client.Stop();
                return;
            }

            if (message.version.ToString() != CURRENT_VERSION)
            {
                client.Send(
                    new IdentificationFailedForBadVersionMessage((sbyte) IdentificationFailureReasonEnum.BAD_VERSION,
                                                                 new Common.Protocol.Net.Types.Version.Version(2,11,2,72101,1,0)));
                client.Stop();
                return;
            }

            byte[] credentials = RSA.Decrypt(message.credentials);
            BigEndianReader reader = new BigEndianReader(credentials);
            reader.Seek(Encoding.UTF8.GetByteCount(salt));
            int lenght = reader.ReadByte();
            string username = Encoding.UTF8.GetString(reader.ReadBytes(lenght));
            string password = Encoding.UTF8.GetString(reader.ReadBytes(reader.Available));

            AccountModel account = AccountsTable.Load(username);
            if (account == null || account.Password != password)
            {
                client.Send(new IdentificationFailedMessage((sbyte)IdentificationFailureReasonEnum.WRONG_CREDENTIALS));
                client.Stop();
            }
            else if (account.Banned)
            {
                client.Send(new IdentificationFailedBannedMessage((sbyte)IdentificationFailureReasonEnum.BANNED, 0));
                client.Stop();
            }
            else
            {
                ValidAccount(account, message.autoconnect);
            }
        }

        [MessageHandler(IdentificationMessage.Id)]
        public void HandleIdentificationMessage(IdentificationMessage message)
        {
            this.message = message;
            QueueManager.Instance.Enqueue(client);
        }

        private void ValidAccount(AccountModel account, bool autoconnect)
        {
            client.Account = account;
            IdentificationSuccessMessage succesMessage = new IdentificationSuccessMessage
                {
                    hasRights = true,
                    wasAlreadyConnected = false,
                    login = account.Username,
                    nickname = account.Nickname,
                    accountId = account.Id,
                    communityId = 1,
                    secretQuestion = account.SecretQuestion,
                    accountCreation = 0,
                    subscriptionEndDate = 1
                };
            client.Send(succesMessage);

            if (!(autoconnect && servers.SelectServer(client.Account.LastServer)))
            {
                client.State = AuthClientStateEnum.SERVER_LIST;
                servers.SendServerList();
            }
        }

        private string GenerateSalt()
        {
            string result = "";
            Random rand = new Random();
            for (int i = 0; i < 32; i++)
            {
                result += (char)rand.Next(255);
            }
            return result;
        }
    }
}
