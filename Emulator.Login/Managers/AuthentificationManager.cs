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
// Created on 26/04/2013 at 17:42
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
        public const string CURRENT_VERSION = "2.11.2.72101.1";

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

            if (message.Version.ToString() != CURRENT_VERSION)
            {
                client.Send(
                    new IdentificationFailedForBadVersionMessage((sbyte) IdentificationFailureReasonEnum.BAD_VERSION,
                                                                 new Common.Protocol.Net.Types.Version.Version(2,11,2,72101,1,0)));
                client.Stop();
                return;
            }

            byte[] credentials = RSA.Decrypt(message.Credentials);
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
                ValidAccount(account, message.Autoconnect);
            }
        }

        [MessageHandler(IdentificationMessage.ID)]
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
                    HasRights = true,
                    WasAlreadyConnected = false,
                    Login = account.Username,
                    Nickname = account.Nickname,
                    AccountId = account.Id,
                    CommunityId = 1,
                    SecretQuestion = account.SecretQuestion,
                    AccountCreation = 0,
                    SubscriptionEndDate = 1
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
